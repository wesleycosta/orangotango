using Orangotango.Core.Messages.Integration;
using Orangotango.Core.Services;
using Orangotango.MessageBus.Settings;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Orangotango.MessageBus.RabbitMQ
{
    internal class RabbitMQBus : IMessageBus
    {
        private readonly ILoggerService _loggerService;
        private BusSettings _busSettings;
        private QueueSettings _queueSettings;
        private IModel _channelSubscribe;

        public RabbitMQBus(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public void Initialize(BusSettings busSettings, QueueSettings queueSettings)
        {
            _busSettings = busSettings;
            _queueSettings = queueSettings;
        }

        protected ConnectionFactory GetConnectionFactory()
        {
            return new ConnectionFactory()
            {
                HostName = _busSettings.HostName,
                Port = _busSettings.Port,
                UserName = _busSettings.UserName,
                Password = _busSettings.Password,
                VirtualHost = _busSettings.VirtualHost
            };
        }

        private static RetryPolicy GetRetryPolicy()
        {
            return Policy.Handle<ConnectFailureException>()
                         .Or<AuthenticationFailureException>()
                         .Or<PossibleAuthenticationFailureException>()
                         .Or<BrokerUnreachableException>()
                         .WaitAndRetryForever(sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(15));
        }

        public void Publish<T>(T integrationEvent) where T : IntegrationEvent
        {
            var policy = GetRetryPolicy();
            policy.Execute(() => PublishInQueue(integrationEvent));
        }

        private void PublishInQueue<T>(T integrationEvent) where T : IntegrationEvent
        {
            var connectionFactory = GetConnectionFactory();
            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(_queueSettings);
            var properties = channel.CreateBasicProperties();

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: _queueSettings.Name,
                                 basicProperties: properties,
                                 body: SerializePayload(integrationEvent));
        }

        private static byte[] SerializePayload<T>(T integrationEvent) where T : IntegrationEvent
        {
            var message = JsonSerializer.Serialize(integrationEvent);
            return Encoding.UTF8.GetBytes(message);
        }

        public void Subscribe(Func<string, Task> onMessage)
        {
            var policy = GetRetryPolicy();
            policy.Execute(() => SubscribeInQueue(onMessage));
        }

        private void SubscribeInQueue(Func<string, Task> onMessage)
        {
            var connectionFactory = GetConnectionFactory();
            var connection = connectionFactory.CreateConnection();
            _channelSubscribe = connection.CreateModel();

            var consumer = CreateConsumer(onMessage);

            _channelSubscribe.BasicQos(0, 1, false);
            _channelSubscribe.QueueDeclare(_queueSettings);
            _channelSubscribe.BasicConsume(queue: _queueSettings.Name, autoAck: false, consumer: consumer);
        }

        private EventingBasicConsumer CreateConsumer(Func<string, Task> onMessage)
        {
            var consumer = new EventingBasicConsumer(_channelSubscribe);
            consumer.Received += (sender, args) =>
            {
                try
                {
                    onMessage.Invoke(args.GetPayload()).Wait();
                }
                catch (Exception exception)
                {
                    _loggerService.Error(exception, args.GetPayload()).Wait();
                }

                _channelSubscribe.BasicAck(args.DeliveryTag);
            };

            return consumer;
        }
    }
}

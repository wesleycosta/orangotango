using Orangotango.Core.Messages.Integration;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Orangotango.MessageBus
{
    public class RabbitMQBus : IRabbitMQBus
    {
        private BusSettings _busSettings;
        private QueueSettings _queueSettings;
        private IModel _channelSubscribe;

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
                         .WaitAndRetry(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        public void Publish<T>(T integrationEvent) where T : IntegrationEvent
        {
            var policy = GetRetryPolicy();
            policy.Execute(() => PublishInQueue(integrationEvent));
        }

        private void PublishInQueue<T>(T integrationEvent) where T : IntegrationEvent
        {
            var ConnectionFactory = GetConnectionFactory();
            using var connection = ConnectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(_queueSettings);
            var message = JsonSerializer.Serialize(integrationEvent);
            var body = Encoding.UTF8.GetBytes(message);
            var properties = channel.CreateBasicProperties();

            channel.BasicPublish(string.Empty, _queueSettings.Name, properties, body);
        }

        public void Subscribe(Func<string, Task> onMessage)
        {
            var policy = GetRetryPolicy();
            policy.Execute(() => SubscribeInQueue(onMessage));
        }

        private void SubscribeInQueue(Func<string, Task> onMessage)
        {
            var connectionFactory = GetConnectionFactory();
            using var connection = connectionFactory.CreateConnection();
            _channelSubscribe = connection.CreateModel();

            var consumer = new EventingBasicConsumer(_channelSubscribe);
            consumer.Received += (o, a) =>
            {
                var json = Encoding.UTF8.GetString(a.Body.ToArray());
                onMessage.Invoke(json).Wait();
                _channelSubscribe.BasicAck(a.DeliveryTag);
            };

            _channelSubscribe.BasicQos(0, 1, false);
            _channelSubscribe.QueueDeclare(_queueSettings);
            _channelSubscribe.BasicConsume(queue: _queueSettings.Name, autoAck: false, consumer: consumer);
        }
    }
}

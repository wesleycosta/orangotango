using System;
using System.Threading.Tasks;
using Orangotango.Core.Messages.Integration;

namespace Orangotango.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private readonly IRabbitMQBus _rabbitMQBus;

        public MessageBus(IRabbitMQBus rabbitMQBus)
        {
            _rabbitMQBus = rabbitMQBus;
        }

        public void Initialize(BusSettings busSettings, QueueSettings queueSetting)
        {
            _rabbitMQBus.Initialize(busSettings, queueSetting);
        }

        public void Publish<T>(T message) where T : IntegrationEvent
        {
            _rabbitMQBus.Publish(message);
        }

        public void Subscribe(Func<string, Task> onMessage)
        {
            _rabbitMQBus.Subscribe(onMessage);
        }
    }
}
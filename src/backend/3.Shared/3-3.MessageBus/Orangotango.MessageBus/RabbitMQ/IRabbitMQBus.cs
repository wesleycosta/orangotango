using Orangotango.Core.Messages.Integration;
using System;
using System.Threading.Tasks;

namespace Orangotango.MessageBus
{
    public interface IRabbitMQBus
    {
        void Initialize(BusSettings busSettings, QueueSettings queueSettings);
        void Publish<T>(T integrationEvent) where T : IntegrationEvent;
        void Subscribe(Func<string, Task> onMessage);
    }
}

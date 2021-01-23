using Orangotango.Core.Messages.Integration;
using Orangotango.MessageBus.Settings;
using System;
using System.Threading.Tasks;

namespace Orangotango.MessageBus
{
    public interface IMessageBus 
    {
        void Initialize(BusSettings busSettings, QueueSettings queueSetting);
        void Publish<T>(T message) where T : IntegrationEvent;
        void Subscribe(Func<string, Task> onMessage);
    }
}
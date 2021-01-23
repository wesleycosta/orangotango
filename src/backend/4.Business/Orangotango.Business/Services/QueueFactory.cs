using Orangotango.Business.Intefaces.Services;
using Orangotango.Business.Models.Types;
using Orangotango.MessageBus.Settings;

namespace Orangotango.Business.Services
{
    public class QueueFactory : IQueueFactory
    {
        public BusSettings GetBusSettings()
        {
            return new BusSettings
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
                VirtualHost = "orangotango"
            };
        }

        public QueueSettings GetQueueSettings(QueueType queueType)
        {
            return new QueueSettings
            {
                Name = queueType.ToString(),
                AutoDelete = false,
                Durable = true,
                Exclusive = false,
            };
        }
    }
}

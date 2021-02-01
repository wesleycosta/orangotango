using Orangotango.Business.Intefaces.Services;
using Orangotango.Business.Models.Types;
using Orangotango.Core.Settings;
using Orangotango.MessageBus.Settings;

namespace Orangotango.Business.Services
{
    public class QueueFactory : IQueueFactory
    {
        private readonly AppSettings _appSettings;

        public QueueFactory(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public BusSettings GetBusSettings()
        {
            return new BusSettings
            {
                HostName = _appSettings.RabbitMQSettings.HostName,
                Port = _appSettings.RabbitMQSettings.Port,
                UserName = _appSettings.RabbitMQSettings.UserName,
                Password = _appSettings.RabbitMQSettings.Password,
                VirtualHost = _appSettings.RabbitMQSettings.VirtualHost
            };
        }

        public QueueSettings GetQueueSettings(QueueType queueType)
        {
            return new QueueSettings
            {
                Name = queueType.ToString(),
                AutoDelete = false,
                Durable = true,
                Exclusive = false
            };
        }
    }
}

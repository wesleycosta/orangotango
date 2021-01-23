using Orangotango.Business.Models.Types;
using Orangotango.MessageBus.Settings;

namespace Orangotango.Business.Intefaces.Services
{
    public interface IQueueFactory
    {
        BusSettings GetBusSettings();
        QueueSettings GetQueueSettings(QueueType queueType);
    }
}

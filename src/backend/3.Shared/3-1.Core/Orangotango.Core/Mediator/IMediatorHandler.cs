using System.Threading.Tasks;
using Orangotango.Core.Messages;

namespace Orangotango.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T eventMessage) where T : Event;
        Task<CommandHandlerResult> SendCommand<T>(T command) where T : Command;
    }
}
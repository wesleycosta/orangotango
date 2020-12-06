using System.Threading.Tasks;
using FluentValidation.Results;
using Orangotango.Core.Messages;

namespace Orangotango.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T eventMessage) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
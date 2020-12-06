using FluentValidation.Results;
using System.Threading.Tasks;
using MediatR;
using Orangotango.Core.Messages;

namespace Orangotango.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public async Task<ValidationResult> SendCommand<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }
    }
}
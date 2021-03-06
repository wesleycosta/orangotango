﻿using System.Threading.Tasks;
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

        public async Task PublishEvent<T>(T eventMessage) where T : Event
        {
            await _mediator.Publish(eventMessage);
        }

        public async Task<CommandHandlerResult> SendCommand<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }
    }
}
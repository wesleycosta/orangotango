using System;
using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;

namespace Orangotango.Core.Messages
{
    public abstract class Command : Message, IRequest<CommandHandlerResult>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
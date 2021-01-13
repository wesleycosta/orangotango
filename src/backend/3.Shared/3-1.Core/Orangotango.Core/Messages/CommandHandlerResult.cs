using FluentValidation.Results;

namespace Orangotango.Core.Messages
{
    public class CommandHandlerResult
    {
        public ValidationResult ValidationResult { get; set; }
        public object Data { get; set; }
    }
}

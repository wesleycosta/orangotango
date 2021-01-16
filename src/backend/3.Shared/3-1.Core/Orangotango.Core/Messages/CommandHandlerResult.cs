using FluentValidation.Results;

namespace Orangotango.Core.Messages
{
    public class CommandHandlerResult
    {
        public ValidationResult ValidationResult { get; init; }
        public object Data { get; init; }

        public bool IsInvalid => 
            ValidationResult?.Errors?.Count > 0;
    }
}
using System.Threading.Tasks;
using FluentValidation.Results;
using Orangotango.Core.Data;

namespace Orangotango.Core.Messages
{
    public abstract class CommandHandler
    {
        public ValidationResult ValidationResult;

        public CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        public void NotifyError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        public async Task<ValidationResult> SaveData(IUnitOfWork uow)
        {
            if (!await uow.Commit())
                NotifyError("Houve um erro ao persistir os dados");

            return ValidationResult;
        }

    }
}
using System.Threading.Tasks;
using FluentValidation.Results;
using Orangotango.Core.Data;

namespace Orangotango.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected async Task<ValidationResult> PersistirDados(IUnitOfWork uow)
        {
            if (!await uow.Commit())
                AddError("Houve um erro ao persistir os dados");

            return ValidationResult;
        }
    }
}
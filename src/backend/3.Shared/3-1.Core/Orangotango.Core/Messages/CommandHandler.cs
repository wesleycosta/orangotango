using System.Threading.Tasks;
using FluentValidation.Results;
using Orangotango.Core.Data;
using Orangotango.Core.DomainObjects;

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

        public async Task<CommandHandlerResult> SaveData(IUnitOfWork unitOfWork)
        {
            return await SaveData(unitOfWork, null);
        }

        public async Task<CommandHandlerResult> SaveData(IUnitOfWork unitOfWork, object responseCommand)
        {
            if (!await unitOfWork.Commit())
            {
                NotifyError("Houve um erro ao persistir os dados");
                responseCommand = null;
            }

            return new CommandHandlerResult
            {
                ValidationResult = ValidationResult,
                Response = responseCommand
            };
        }

        public CommandHandlerResult Response()
        {
            return new CommandHandlerResult
            {
                ValidationResult = ValidationResult
            };
        }

        public CommandHandlerResult Response(Command command)
        {
            ValidationResult = command.ValidationResult;
            return new CommandHandlerResult
            {
                ValidationResult = ValidationResult
            };
        }

        public CommandHandlerResult Response(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
            return new CommandHandlerResult
            {
                ValidationResult = ValidationResult
            };
        }

        public CommandHandlerResult Response(object responseCommand)
        {
            return new CommandHandlerResult
            {
                ValidationResult = ValidationResult,
                Response = responseCommand
            };
        }

        public static CommandHandlerResult Response(CommandHandlerResult commandHandlerResult)
        {
            return commandHandlerResult;
        }

        public static void EntryNotFoundException()
        {
            throw new DomainException("Registro não encontrado na base de dados");
        }
    }
}
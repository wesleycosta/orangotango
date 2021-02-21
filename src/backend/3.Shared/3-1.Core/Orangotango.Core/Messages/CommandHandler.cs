using System;
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

        public async Task<CommandHandlerResult> SaveData(IUnitOfWork unitOfWork, object data)
        {
            if (!await unitOfWork.Commit())
            {
                NotifyError("Houve um erro ao persistir os dados");
                data = null;
            }

            return new CommandHandlerResult
            {
                ValidationResult = ValidationResult,
                Data = data
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

        public CommandHandlerResult Response(object data)
        {
            return new CommandHandlerResult
            {
                ValidationResult = ValidationResult,
                Data = data
            };
        }

        public static CommandHandlerResult Response(CommandHandlerResult data)
        {
            return data;
        }

        public static void EntryNotFoundException()
        {
            throw new DomainException("Registro não encontrado na base de dados");
        }
    }
}
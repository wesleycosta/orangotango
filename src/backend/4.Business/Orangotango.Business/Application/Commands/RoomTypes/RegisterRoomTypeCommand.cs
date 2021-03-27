using FluentValidation;
using Orangotango.Business.Application.Inputs.RoomTypes;
using Orangotango.Business.Helpers;
using Orangotango.Core.Messages;
using System;

namespace Orangotango.Business.Application.Commands.RoomTypes
{
    public class RegisterRoomTypeCommand : Command
    {
        public RegisterRoomTypeInputModel InputModel { get; private set; }

        public RegisterRoomTypeCommand(RegisterRoomTypeInputModel inputModel)
        {
            AggregateId = Guid.NewGuid();
            InputModel = inputModel;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterRoomTypeValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RegisterRoomTypeValidation : AbstractValidator<RegisterRoomTypeCommand>
        {
            public RegisterRoomTypeValidation()
            {
                RuleFor(registerRoomTypeCommand => registerRoomTypeCommand.AggregateId)
                    .NotEqual(Guid.Empty)
                    .WithMessage(ValidationMessageHelper.IdentifierIsInvalid());

                RuleFor(registerRoomTypeCommand => registerRoomTypeCommand.InputModel.Name)
                    .NotEmpty()
                    .WithMessage(ValidationMessageHelper.NotInformed("nome da categoria do quarto"));
            }
        }
    }
}

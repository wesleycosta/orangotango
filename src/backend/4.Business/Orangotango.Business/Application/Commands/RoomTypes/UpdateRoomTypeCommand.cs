using FluentValidation;
using Orangotango.Business.Application.Inputs.RoomTypes;
using Orangotango.Core.Messages;
using System;

namespace Orangotango.Business.Application.Commands.RoomTypes
{
    public class UpdateRoomTypeCommand : Command
    {
        public UpdateRoomTypeInputModel Input { get; private set; }

        public UpdateRoomTypeCommand(UpdateRoomTypeInputModel input)
        {
            AggregateId = input.Id;
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateRoomTypeValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class UpdateRoomTypeValidation : AbstractValidator<UpdateRoomTypeCommand>
        {
            public UpdateRoomTypeValidation()
            {
                RuleFor(updateRoomTypeCommand => updateRoomTypeCommand.AggregateId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do usuário inválido");

                RuleFor(updateRoomTypeCommand => updateRoomTypeCommand.Input.Name)
                    .NotEmpty()
                    .WithMessage("O nome da categoria do quarto não foi informado");
            }
        }
    }
}

using FluentValidation;
using Orangotango.Business.Application.Inputs.RoomTypes;
using Orangotango.Core.Messages;
using System;

namespace Orangotango.Business.Application.Commands.RoomTypes
{
    public class RegisterRoomTypeCommand : Command
    {
        public Guid Id { get; set; }
        public RegisterRoomTypeInputModel Input { get; private set; }

        public RegisterRoomTypeCommand(RegisterRoomTypeInputModel input)
        {
            Id = Guid.NewGuid();
            AggregateId = Id;
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RegisterUserValidation : AbstractValidator<RegisterRoomTypeCommand>
        {
            public RegisterUserValidation()
            {
                RuleFor(user => user.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do usuário inválido");

                RuleFor(user => user.Input.Name)
                    .NotEmpty()
                    .WithMessage("O nome da categoria do quarto não foi informado");
            }
        }
    }
}

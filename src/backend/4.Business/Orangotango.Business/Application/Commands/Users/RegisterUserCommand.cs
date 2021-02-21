using FluentValidation;
using Orangotango.Business.Application.Inputs.Users;
using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.Messages;
using System;

namespace Orangotango.Business.Application.Commands.Users
{
    public class RegisterUserCommand : Command
    {
        public RegisterUserInputModel Input { get; private set; }

        public RegisterUserCommand(RegisterUserInputModel input)
        {
            AggregateId = Guid.NewGuid();
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RegisterUserValidation : AbstractValidator<RegisterUserCommand>
        {
            public RegisterUserValidation()
            {
                RuleFor(registerUserCommand => registerUserCommand.AggregateId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do usuário inválido");

                RuleFor(registerUserCommand => registerUserCommand.Input.Name)
                    .NotEmpty()
                    .WithMessage("O nome do usuário não foi informado");

                RuleFor(registerUserCommand => registerUserCommand.Input.EmailAddress)
                    .Must(email => Email.IsValid(email))
                    .WithMessage("O e-mail informado é inválido");
            }
        }
    }
}

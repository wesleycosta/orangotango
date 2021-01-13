using FluentValidation;
using Orangotango.Business.Application.Inputs.Users;
using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.Messages;
using System;

namespace Orangotango.Business.Application.Commands.Users
{
    public class RegisterUserCommand : Command
    {
        public Guid Id { get; set; }
        public RegisterUserInputModel Input { get; private set; }

        public RegisterUserCommand(RegisterUserInputModel input)
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

        public class RegisterUserValidation : AbstractValidator<RegisterUserCommand>
        {
            public RegisterUserValidation()
            {
                RuleFor(user => user.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do usuário inválido");

                RuleFor(user => user.Input.Name)
                    .NotEmpty()
                    .WithMessage("O nome do usuário não foi informado");

                RuleFor(user => user.Input.EmailAddress)
                    .Must(email => Email.IsValid(email))
                    .WithMessage("O e-mail informado é inválido");
            }
        }
    }
}

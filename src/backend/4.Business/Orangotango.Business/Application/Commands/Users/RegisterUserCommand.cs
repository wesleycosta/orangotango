using FluentValidation;
using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.Messages;
using System;

namespace Orangotango.Business.Application.Commands.Users
{
    public class RegisterUserCommand : Command
    {
        public Guid Id { get; private set; }
        public string Name { get; init; }
        public string EmailAddress { get; init; }

        public RegisterUserCommand()
        {
            Id = Guid.NewGuid();
            AggregateId = Id;
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
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do usuário inválido");

                RuleFor(c => c.Name)
                    .NotEmpty()
                    .WithMessage("O nome do usuário não foi informado");

                RuleFor(c => c.EmailAddress)
                    .Must(TerEmailValido)
                    .WithMessage("O e-mail informado é inválido");
            }

            protected static bool TerEmailValido(string email)
            {
                return Email.IsValid(email);
            }
        }
    }
}

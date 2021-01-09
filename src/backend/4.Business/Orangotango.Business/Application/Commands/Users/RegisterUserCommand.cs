using FluentValidation;
using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.Messages;
using System;

namespace Orangotango.Business.Application.Commands.Users
{
    public class RegisterUserCommand : Command
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string EmailAddress { get; private set; }

        public RegisterUserCommand(Guid id, string name, string email)
        {
            AggregateId = id;
            Id = id;
            Name = name;
            EmailAddress = email;
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
                    .WithMessage("Id do cliente inválido");

                RuleFor(c => c.Name)
                    .NotEmpty()
                    .WithMessage("O nome do cliente não foi informado");

                RuleFor(c => c.EmailAddress)
                    .Must(TerEmailValido)
                    .WithMessage("O e-mail informado não é válido.");
            }

            protected static bool TerEmailValido(string email)
            {
                return Email.IsValid(email);
            }
        }
    }
}

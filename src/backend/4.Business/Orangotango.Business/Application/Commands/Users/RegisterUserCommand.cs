using FluentValidation;
using Orangotango.Business.Application.Inputs.Users;
using Orangotango.Business.Helpers;
using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.Messages;
using System;

namespace Orangotango.Business.Application.Commands.Users
{
    public class RegisterUserCommand : Command
    {
        public RegisterUserInputModel InputModel { get; private set; }

        public RegisterUserCommand(RegisterUserInputModel inputModel)
        {
            AggregateId = Guid.NewGuid();
            InputModel = inputModel;
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
                    .WithMessage(ValidationMessageHelper.IdentifierIsInvalid());

                RuleFor(registerUserCommand => registerUserCommand.InputModel.Name)
                    .NotEmpty()
                    .WithMessage(ValidationMessageHelper.NotInformed("nome do usuário"));

                RuleFor(registerUserCommand => registerUserCommand.InputModel.EmailAddress)
                    .Must(email => Email.IsValid(email))
                    .WithMessage(ValidationMessageHelper.IsInvalid("email"));
            }
        }
    }
}

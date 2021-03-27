using FluentValidation;
using Orangotango.Business.Application.Inputs;
using Orangotango.Business.Helpers;
using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.Messages;

namespace Orangotango.Business.Application.Commands.Users
{
    public class SignInUserCommand : Command
    {
        public SignInUserInputModel InputModel { get; init; }

        public override bool IsValid()
        {
            ValidationResult = new LoginUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class LoginUserValidation : AbstractValidator<SignInUserCommand>
        {
            public LoginUserValidation()
            {
                RuleFor(signInUserCommand => signInUserCommand.InputModel.EmailAdrress)
                    .Must(email => Email.IsValid(email))
                    .WithMessage(ValidationMessageHelper.IsInvalid("e-mail"));

                RuleFor(signInUserCommand => signInUserCommand.InputModel.Password)
                    .Must(password => Password.IsValid(password))
                    .WithMessage(ValidationMessageHelper.IsInvalid("senha"));
            }
        }
    }
}

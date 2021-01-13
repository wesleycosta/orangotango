using FluentValidation;
using Orangotango.Business.Application.Inputs;
using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.Messages;

namespace Orangotango.Business.Application.Commands.Users
{
    public class MakeLoginUserCommand : Command
    {
        public MakeLoginUserInputModel Input { get; init; }

        public override bool IsValid()
        {
            ValidationResult = new LoginUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class LoginUserValidation : AbstractValidator<MakeLoginUserCommand>
        {
            public LoginUserValidation()
            {
                RuleFor(user => user.Input.EmailAdrress)
                    .Must(email => Email.IsValid(email))
                    .WithMessage("O e-mail informado é inválido");

                RuleFor(password => password.Input.Password)
                    .Must(password => Password.IsValid(password))
                    .WithMessage("A senha informada é inválida");
            }
        }
    }
}

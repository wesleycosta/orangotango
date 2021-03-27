using FluentValidation;
using Orangotango.Business.Helpers;
using Orangotango.Business.ViewModels.SendEmail;
using Orangotango.Core.Messages;
using System;

namespace Orangotango.Business.Application.Commands.Emails
{
    public class SendEmailCommand : Command
    {
        public EmailContentInputModel InputModel { get; private set; }

        public SendEmailCommand(EmailContentInputModel inputModel)
        {
            AggregateId = Guid.NewGuid();
            InputModel = inputModel;
        }

        public override bool IsValid()
        {
            ValidationResult = new SendEmailCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class SendEmailCommandValidation : AbstractValidator<SendEmailCommand>
        {
            public SendEmailCommandValidation()
            {
                RuleFor(sendEmailCommand => sendEmailCommand.InputModel.Subject)
                    .NotEmpty()
                    .WithMessage(ValidationMessageHelper.NotInformed("assunto do e-mail"));

                RuleFor(sendEmailCommand => sendEmailCommand.InputModel.Body)
                    .NotEmpty()
                    .WithMessage(ValidationMessageHelper.NotInformed("corpo do e-mail"));

                RuleFor(sendEmailCommand => sendEmailCommand.InputModel.To)
                    .NotNull()
                    .WithMessage(ValidationMessageHelper.NotInformed("destinatário do e-mail"));
            }
        }
    }
}

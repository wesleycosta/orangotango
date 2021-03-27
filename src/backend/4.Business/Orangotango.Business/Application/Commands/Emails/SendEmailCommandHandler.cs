using MediatR;
using Orangotango.Business.ViewModels.SendEmail;
using Orangotango.Core.Messages;
using Orangotango.Core.Services;
using Orangotango.Core.Settings;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Orangotango.Business.Application.Commands.Emails
{
    public class SendEmailCommandHandler : CommandHandler, IRequestHandler<SendEmailCommand, CommandHandlerResult>
    {
        private readonly ILoggerService _loggerService;

        public SendEmailCommandHandler(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public async Task<CommandHandlerResult> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return Response();

            return Response(await SendEmail(request.InputModel));
        }

        private async Task<bool> SendEmail(EmailContentInputModel inputModel)
        {
            try
            {
                var message = GetMailMessage(inputModel);
                var client = GetSmtpClient();
                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                await _loggerService.Error(ex);
                return false;
            }
        }

        private static MailMessage GetMailMessage(EmailContentInputModel inputModel)
        {
            var settings = EmailSettings.GetSettings();
            var from = new MailAddress(settings.Email, settings.From);

            var mailMessage = new MailMessage
            {
                From = from,
                Subject = inputModel.Subject,
                Body = inputModel.Body,
                IsBodyHtml = true
            };

            AddToEmailsAddress(mailMessage, inputModel);

            return mailMessage;
        }

        private static void AddToEmailsAddress(MailMessage mailMessage, EmailContentInputModel inputModel)
        {
            inputModel?.To?.ForEach(mail => mailMessage.To.Add(mail));
        }

        private static SmtpClient GetSmtpClient()
        {
            var settings = EmailSettings.GetSettings();

            return new SmtpClient
            {
                Credentials = new NetworkCredential(settings.Email, settings.Password),
                Host = settings.Host,
                Port = settings.Port,
                EnableSsl = true
            };
        }
    }
}

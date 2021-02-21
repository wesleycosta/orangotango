using Orangotango.Business.Intefaces.Services;
using Orangotango.Business.ViewModels.SendEmail;
using Orangotango.Core.Services;
using Orangotango.Core.Settings;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Orangotango.Business.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILoggerService _loggerService;

        public EmailService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public async Task<bool> Send(EmailContentViewModel emailContent)
        {
            try
            {
                var message = GetMailMessage(emailContent);
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

        private static MailMessage GetMailMessage(EmailContentViewModel emailContent)
        {
            var settings = EmailSettings.GetSettings();
            var from = new MailAddress(settings.Email, settings.From);

            var mailMessage = new MailMessage
            {
                From = from,
                Subject = emailContent.Subject,
                Body = emailContent.Body,
                IsBodyHtml = true
            };

            AddToEmailsAddress(mailMessage, emailContent);

            return mailMessage;
        }

        private static void AddToEmailsAddress(MailMessage mailMessage, EmailContentViewModel emailContent)
        {
            emailContent?.To?.ForEach(mail => mailMessage.To.Add(mail));
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

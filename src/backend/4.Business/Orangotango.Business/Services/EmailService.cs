using Orangotango.Business.Configurations.Settings;
using Orangotango.Business.Intefaces.Services;
using Orangotango.Core.Services;
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

        public async Task<bool> Send(string to, string subject, string body)
        {
            try
            {
                var message = GetMailMessage(to, subject, body);
                good practices                var client = GetSmtpClient();
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                await _loggerService.Error(ex);
                return false;
            }
        }

        private static MailMessage GetMailMessage(string toAddress, string subject, string body)
        {
            var settings = EmailSettings.GetSettings();
            var from = new MailAddress(settings.Email, settings.From);
            var to = new MailAddress(toAddress);

            return new MailMessage(from, to)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
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

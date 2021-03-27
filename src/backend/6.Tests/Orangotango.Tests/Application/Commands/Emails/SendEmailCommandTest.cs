using Orangotango.Business.Application.Commands.Emails;
using Orangotango.Business.ViewModels.SendEmail;
using Orangotango.Tests.Infrastructure.Fakes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Orangotango.Tests.Application.Commands.Users
{
    public class SendEmailCommandTest
    {
        [Fact]
        public async Task SenndEmail_Executed_ShouldExcuteSuccessfully()
        {
            // Arrange
            var inputModel = new EmailContentInputModel
            {
                Subject = "Subject",
                Body = "Body",
                To = new List<string>
                {
                    "wesley.wldc@gmail.com"
                }
            };

            var sendEmailCommand = new SendEmailCommand(inputModel);
            var sendEmailCommandHandler = new SendEmailCommandHandler(new LoggerServiceFake());

            // Act
            var commandHandlerResult = await sendEmailCommandHandler.Handle(sendEmailCommand, new CancellationToken());

            // Assert
            Assert.NotNull(commandHandlerResult);
            Assert.NotNull(commandHandlerResult.Response);
            Assert.False(string.IsNullOrEmpty(commandHandlerResult.Response.ToString()));
        }
    }
}

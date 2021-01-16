using Moq;
using Orangotango.Business.Application.Commands.Users;
using Orangotango.Business.Application.Inputs;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;
using Orangotango.Business.Models.ValueObjects;
using Orangotango.Tests.Fakes;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Orangotango.Tests.Application.Commands.Users
{
    public class SignInUserCommandTest
    {
        private static Mock<IUserRepository> GetUserRepositoryMock()
        {
            var user = new User
            {
                Email = new Email("wesley.costa@mail.com"),
                Password = new Password("MinhaSenha@123")
            };
            user.Password.CreateHash();

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(respository => respository.GetByEmailAndPassword(It.IsAny<Email>(), It.IsAny<string>()))
                                                           .Returns(Task.FromResult(user));
            return userRepository;
        }

        [Fact]
        public async Task SignIn_Executed_Success()
        {
            var signInCommand = new SignInUserCommand
            {
                Input = new SignInUserInputModel
                {
                    EmailAdrress = "wesley.costa@mail.com",
                    Password = "MinhaSenha@123"
                }
            };

            var userRepository = GetUserRepositoryMock();
            var signInUserCommandHandler = new SignInUserCommandHandler(userRepository.Object, new AutenticationFake());
            var commandHandlerResult = await signInUserCommandHandler.Handle(signInCommand, new CancellationToken());

            Assert.NotNull(commandHandlerResult);
            Assert.NotNull(commandHandlerResult.Data);
            Assert.False(string.IsNullOrEmpty(commandHandlerResult.Data.ToString()));
        }
    }
}

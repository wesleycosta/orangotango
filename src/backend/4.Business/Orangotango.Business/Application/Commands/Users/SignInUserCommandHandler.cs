using MediatR;
using Orangotango.Business.Application.Inputs;
using Orangotango.Business.Intefaces.Infrastructure;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;
using Orangotango.Business.Models.ValueObjects;
using Orangotango.Business.ViewModels.Users;
using Orangotango.Core.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace Orangotango.Business.Application.Commands.Users
{
    public class SignInUserCommandHandler : CommandHandler, IRequestHandler<SignInUserCommand, CommandHandlerResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtAuthentication _jwtAuthentication;

        public SignInUserCommandHandler(IUserRepository userRepository,
                                           IJwtAuthentication jwtAuthentication)
        {
            _userRepository = userRepository;
            _jwtAuthentication = jwtAuthentication;
        }

        public async Task<CommandHandlerResult> Handle(SignInUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return Response(message);

            var user = await GetUserByCredential(message.Input);
            if (user == null)
            {
                NotifyError("E-mail ou senha inválido");
                return Response();
            }

            var token = _jwtAuthentication.GenerateToken(new UserAuthViewModel
            {
                Id = user.Id,
                Email = user.Email.Address
            });

            return Response(token);
        }

        private async Task<User> GetUserByCredential(SignInUserInputModel input)
        {
            var email = new Email(input.EmailAdrress);
            var password = new Password(input.Password);
            return await _userRepository.GetByEmailAndPassword(email, password.CreateHash());
        }
    }
}

using AutoMapper;
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
        private readonly IMapper _mapper;

        public SignInUserCommandHandler(IUserRepository userRepository,
                                        IJwtAuthentication jwtAuthentication,
                                        IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtAuthentication = jwtAuthentication;
            _mapper = mapper;
        }

        public async Task<CommandHandlerResult> Handle(SignInUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return Response(message);

            if (!await BusinessIsValid(message))
                return Response();

            return Response(await GenerateToken(message));
        }

        private async Task<bool> BusinessIsValid(SignInUserCommand message)
        {
            var user = await GetUserByCredential(message.InputModel);
            if (user == null)
            {
                NotifyError("E-mail ou senha inválido");
                return false;
            }

            return true;
        }

        private async Task<UserAuthResponseViewModel> GenerateToken(SignInUserCommand message)
        {
            var user = await GetUserByCredential(message.InputModel);
            var userAuthViewModel = _mapper.Map<UserAuthViewModel>(user);
            var token = _jwtAuthentication.GenerateToken(userAuthViewModel);

            return new UserAuthResponseViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email.Address,
                Token = token
            };
        }

        private async Task<User> GetUserByCredential(SignInUserInputModel input)
        {
            var email = new Email(input.EmailAdrress);
            var password = new Password(input.Password);
            return await _userRepository.GetByEmailAndPassword(email, password.CreateHash());
        }
    }
}

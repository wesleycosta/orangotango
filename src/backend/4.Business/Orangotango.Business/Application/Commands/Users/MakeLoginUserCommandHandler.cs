using FluentValidation.Results;
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
    public class MakeLoginUserCommandHandler : CommandHandler, IRequestHandler<MakeLoginUserCommand, ValidationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtAuthentication _jwtAuthentication;

        public MakeLoginUserCommandHandler(IUserRepository userRepository,
                                           IJwtAuthentication jwtAuthentication)
        {
            _userRepository = userRepository;
            _jwtAuthentication = jwtAuthentication;
        }

        public async Task<ValidationResult> Handle(MakeLoginUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var user = await GetUserByCredential(message.Input);
            if (user == null)
            {
                NotifyError("E-mail ou senha inválido");
                return ValidationResult;
            }

            var token = _jwtAuthentication.GenerateToken(new UserAuthViewModel
            {
                Id = user.Id,
                Email = user.Email.Address
            });

            NotifyError(token);
            return ValidationResult;
        }

        private async Task<User> GetUserByCredential(MakeLoginUserInputModel input)
        {
            var email = new Email(input.EmailAdrress);
            var password = new Password(input.Password);
            return await _userRepository.GetByEmailAndPassword(email, password.CreateHash());
        }
    }
}

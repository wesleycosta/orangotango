using FluentValidation.Results;
using MediatR;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;
using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace Orangotango.Business.Application.Commands.Users
{
    public class UserCommandHandler : CommandHandler,
        IRequestHandler<RegisterUserCommand, ValidationResult>
    {
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ValidationResult> Handle(RegisterUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var user = new User
            {
                Name = message.Name,
                Email = new Email(message.EmailAddress)
            };

            if (await ExistsWithSameEmail(user.Email))
            {
                AddError("Este e-mail já está em uso.");
                return ValidationResult;
            }

            _userRepository.Add(user);
            return await SaveData(_userRepository.UnitOfWork);
        }

        private async Task<bool> ExistsWithSameEmail(Email email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            return user != null;
        }
    }
}

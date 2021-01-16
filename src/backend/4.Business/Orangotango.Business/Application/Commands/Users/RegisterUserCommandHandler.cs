using MediatR;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;
using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace Orangotango.Business.Application.Commands.Users
{
    public partial class RegisterUserCommandHandler : CommandHandler, IRequestHandler<RegisterUserCommand, CommandHandlerResult>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CommandHandlerResult> Handle(RegisterUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return Response(message);

            var user = new User
            {
                Name = message.Input.Name,
                Email = new Email(message.Input.EmailAddress)
            };

            if (await _userRepository.ExistsWithSameEmail(user.Email))
            {
                NotifyError("Este e-mail já está em uso");
                return Response();
            }

            _userRepository.Add(user);
            return Response(await SaveData(_userRepository.UnitOfWork));
        }
    }
}

using MediatR;
using Orangotango.Business.Application.Events.Users;
using Orangotango.Business.Application.Inputs.Users;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;
using Orangotango.Business.Models.Types;
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

            if (!await BusinessIsValid(message.Input))
                return Response();

            var user = AddUser(message.Input);
            SendFirstAccessEmailEvent(user);

            return Response(await SaveData(_userRepository.UnitOfWork));
        }

        private async Task<bool> BusinessIsValid(RegisterUserInputModel inputModel)
        {
            if (await _userRepository.ExistsWithSameEmail(new Email(inputModel.EmailAddress)))
            {
                NotifyError("Este e-mail já está em uso");
                return false;
            }

            return true;
        }

        private User AddUser(RegisterUserInputModel inputModel)
        {
            var user = new User
            {
                Name = inputModel.Name,
                Email = new Email(inputModel.EmailAddress)
            };

            _userRepository.Add(user);

            return user;
        }

        private static void SendFirstAccessEmailEvent(User user)
        {
            var registeredUserEvent = new RegisteredUserEvent
            {
                AggregateId = user.Id,
                Name = user.Name,
                Email = user.Email,
                Type = EmailTemplateType.FirstAccess
            };

            user.AddEvent(registeredUserEvent);
        }
    }
}

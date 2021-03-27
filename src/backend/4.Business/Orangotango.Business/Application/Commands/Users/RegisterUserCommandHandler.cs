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

        public async Task<CommandHandlerResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return Response(request);

            if (!await BusinessIsValid(request.InputModel))
                return Response();

            return Response(await AddUserAndSaveData(request));
        }

        private async Task<bool> BusinessIsValid(RegisterUserInputModel inputModel)
        {
            if (await _userRepository.HasEmail(new Email(inputModel.EmailAddress)))
            {
                NotifyError("Este e-mail já está em uso");
                return false;
            }

            return true;
        }

        private async Task<CommandHandlerResult> AddUserAndSaveData(RegisterUserCommand request)
        {
            var user = AddUser(request);
            SendFirstAccessEmailEvent(user);

            return await SaveData(_userRepository.UnitOfWork);
        }

        private User AddUser(RegisterUserCommand request)
        {
            var user = new User
            {
                Id = request.AggregateId,
                Name = request.InputModel.Name,
                Email = new Email(request.InputModel.EmailAddress)
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

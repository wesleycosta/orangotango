using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Orangotango.Business.Application.Commands.Users;
using Orangotango.Business.Hubs;
using Orangotango.Business.Intefaces.Queries;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Core.Mediator;
using Orangotango.Core.Notifications;
using Orangotango.WebApiShared.Controllers;
using System;
using System.Threading.Tasks;

namespace Orangotango.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : MainController
    {
        private readonly IUserQueries _userQueries;
        private readonly IHubContext<NotificationHub> _hub;
        private readonly IUserRepository _userRepository;
        private readonly IMediatorHandler _mediator;

        public UsersController(INotifier notifier,
                               IUserQueries userQueries,
                               IHubContext<NotificationHub> hub,
                               IUserRepository userRepository,
                               IMediatorHandler mediatorHandler) : base(notifier)
        {
            _userQueries = userQueries;
            _hub = hub;
            _userRepository = userRepository;
            _mediator = mediatorHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CustomResponse(await _userRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Insert()
        {
            var command = new RegisterUserCommand
            {
                Name = "Wesley Costa",
                EmailAddress = "wesley_costa@outlook.com"
            };

            return CustomResponse(await _mediator.SendCommand(command));
        }

        [HttpGet("get-by-email")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            return CustomResponse(await _userQueries.GetUserByEmail(email));
        }

        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessages()
        {
            var message = $"Messagem {new Random().Next(0, int.MaxValue - 1)}";
            await _hub.Clients.All.SendAsync("NotificationAll", message);
            return CustomResponse(message);
        }
    }
}

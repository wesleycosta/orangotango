using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Orangotango.Api.Infrastructure.Controllers;
using Orangotango.Business.Application.Commands.Users;
using Orangotango.Business.Application.Inputs.Users;
using Orangotango.Business.Intefaces.Queries;
using Orangotango.Business.ViewModels;
using Orangotango.Core.Mediator;
using Orangotango.Core.Notifications;
using System;
using System.Threading.Tasks;

namespace Orangotango.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : MainController
    {
        private readonly IUserQueries _userQueries;
        private readonly IMediatorHandler _mediator;
        private readonly ILogger<UserViewModel> _logger;

        public UsersController(INotifier notifier,
                               IUserQueries userQueries,
                               IMediatorHandler mediatorHandler,
                               ILogger<UserViewModel> logger) : base(notifier)
        {
            _userQueries = userQueries;
            _mediator = mediatorHandler;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return CustomResponse(await _userQueries.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "arg1", "arg2");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(RegisterUserInputModel input)
        {
            var command = new RegisterUserCommand(input);
            return CustomResponse(await _mediator.SendCommand(command));
        }

        [HttpGet("get-by-email")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            return CustomResponse(await _userQueries.GetUserByEmail(email));
        }

        [HttpGet("has-email")]
        public async Task<IActionResult> HasEmail(string email)
        {
            return CustomResponse(await _userQueries.HasEmail(email));
        }
    }
}

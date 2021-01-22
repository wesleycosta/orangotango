using Microsoft.AspNetCore.Mvc;
using Orangotango.Api.Infrastructure.Controllers;
using Orangotango.Business.Application.Commands.Users;
using Orangotango.Business.Application.Inputs.Users;
using Orangotango.Business.Intefaces.Queries;
using Orangotango.Core.Mediator;
using Orangotango.Core.Notifications;
using System.Threading.Tasks;

namespace Orangotango.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : MainController
    {
        private readonly IUserQueries _userQueries;
        private readonly IMediatorHandler _mediator;

        public UsersController(INotifier notifier,
                               IUserQueries userQueries,
                               IMediatorHandler mediatorHandler) : base(notifier)
        {
            _userQueries = userQueries;
            _mediator = mediatorHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CustomResponse(await _userQueries.GetAll());
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
    }
}

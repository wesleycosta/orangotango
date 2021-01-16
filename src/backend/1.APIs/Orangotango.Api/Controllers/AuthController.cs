using Microsoft.AspNetCore.Mvc;
using Orangotango.Api.Infrastructure.Controllers;
using Orangotango.Business.Application.Commands.Users;
using Orangotango.Business.Application.Inputs;
using Orangotango.Core.Mediator;
using Orangotango.Core.Notifications;
using System.Threading.Tasks;

namespace Orangotango.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : MainController
    {
        private readonly IMediatorHandler _mediator;

        public AuthController(INotifier notifier,
                              IMediatorHandler mediatorHandler) : base(notifier)
        {
            _mediator = mediatorHandler;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInUserInputModel input)
        {
            var command = new SignInUserCommand { Input = input };
            return CustomResponse(await _mediator.SendCommand(command));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Orangotango.Core.Notifications;
using Orangotango.WebApiShared.Authentication.Interfaces;
using Orangotango.WebApiShared.Authentication.ViewModels;
using Orangotango.WebApiShared.Controllers;

namespace Orangotango.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : MainController
    {
        private readonly IJwtAuthentication _jwtAuthentication;

        public AuthController(IJwtAuthentication jwtAuthentication,
                              INotifier notifier) : base(notifier)
        {
            _jwtAuthentication = jwtAuthentication;
        }

        [HttpGet]
        public IActionResult Get(UserAuthViewModel user)
        {
            return Ok(_jwtAuthentication.GenareteToken(user));
        }
    }
}

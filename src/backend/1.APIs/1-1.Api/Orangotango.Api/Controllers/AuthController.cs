using Microsoft.AspNetCore.Mvc;
using Orangotango.WebApiShared.Authentication.Interfaces;
using Orangotango.WebApiShared.Authentication.ViewModels;

namespace Orangotango.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IJwtAuthentication _jwtAuthentication;

        public AuthController(IJwtAuthentication jwtAuthentication)
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

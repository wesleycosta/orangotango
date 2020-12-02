using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orangotango.WebApiShared.User;

namespace Orangotango.Api.Controllers
{
    [Route("api/secret")]
    [Authorize("Bearer")]
    public class SecretController : Controller
    {
        private readonly IAspNetUser _aspNetUser;

        public SecretController(IAspNetUser aspNetUser)
        {
            _aspNetUser = aspNetUser;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"Secret {_aspNetUser.GetEmail()} {_aspNetUser.GetUserId()}");
        }
    }
}

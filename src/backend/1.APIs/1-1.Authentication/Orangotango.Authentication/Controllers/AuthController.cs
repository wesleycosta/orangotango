using Microsoft.AspNetCore.Mvc;

namespace Orangotango.Authentication.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("deu certo");
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Orangotango.Api.Controllers
{
    [Route("api/secret")]
    [Authorize("Bearer")]
    public class SecretController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Secret");
        }
    }
}

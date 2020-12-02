using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orangotango.Core.Notifications;
using Orangotango.WebApiShared.Controllers;

namespace Orangotango.Api.Controllers
{
    [Route("api/secret")]
    [Authorize("Bearer")]
    public class SecretController : MainController
    {
        public SecretController(INotifier notifier) : base(notifier)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return CustomResponse();
        }
    }
}

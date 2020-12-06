using Microsoft.AspNetCore.Mvc;
using Orangotango.Core.Notifications;
using Orangotango.WebApiShared.Controllers;

namespace Orangotango.Api.Controllers
{
    [Route("api/secret")]
    public class SecretController : MainControllerWithBearer
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

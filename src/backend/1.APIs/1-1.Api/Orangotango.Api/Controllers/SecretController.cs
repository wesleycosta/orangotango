using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orangotango.Business.Intefaces.Queries;
using Orangotango.Core.Notifications;
using Orangotango.WebApiShared.Controllers;
using System.Threading.Tasks;

namespace Orangotango.Api.Controllers
{
    [Route("api/secret")]
    public class SecretController : MainControllerWithBearer
    {
        private readonly IUserQueries _userQueries;

        public SecretController(INotifier notifier,
                                IUserQueries userQueries) : base(notifier)
        {
            _userQueries = userQueries;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return CustomResponse();
        }

        [HttpGet("get-by-email")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByEmail()
        {
            return CustomResponse(await _userQueries.GetUserByEmail("wesley_costa@outlook.com"));
        }
    }
}

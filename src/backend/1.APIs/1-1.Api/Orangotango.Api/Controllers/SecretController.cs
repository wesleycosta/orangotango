using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Orangotango.Business.Hubs;
using Orangotango.Business.Intefaces.Queries;
using Orangotango.Core.Notifications;
using Orangotango.WebApiShared.Controllers;
using System;
using System.Threading.Tasks;

namespace Orangotango.Api.Controllers
{
    [Route("api/secret")]
    public class SecretController : MainControllerWithBearer
    {
        private readonly IUserQueries _userQueries;
        private IHubContext<NotificationHub> _hub;

        public SecretController(INotifier notifier,
                                IUserQueries userQueries,
                                IHubContext<NotificationHub> hub) : base(notifier)
        {
            _userQueries = userQueries;
            _hub = hub;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return CustomResponse();
        }

        [AllowAnonymous]
        [HttpGet("get-by-email")]
        public async Task<IActionResult> GetByEmail()
        {
            return CustomResponse(await _userQueries.GetUserByEmail("wesley_costa@outlook.com"));
        }

        [AllowAnonymous]
        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessages()
        {
            var message = $"Messagem {new Random().Next(0, int.MaxValue - 1)}";
            await _hub.Clients.All.SendAsync("NotificationAll", message);
            return CustomResponse(message);
        }
    }
}

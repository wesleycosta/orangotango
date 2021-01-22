using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Orangotango.Api.Infrastructure.Controllers;
using Orangotango.Business.Hubs;
using Orangotango.Core.Notifications;
using System;
using System.Threading.Tasks;

namespace Orangotango.Api.Controllers
{
    [Route("api/web-socket")]
    public class WebSocketController : MainController
    {
        private readonly IHubContext<NotificationHub> _hub;

        public WebSocketController(INotifier notifier,
                                   IHubContext<NotificationHub> hub) : base(notifier)
        {
            _hub = hub;
        }

        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessages()
        {
            var message = $"Messagem {new Random().Next(0, int.MaxValue - 1)}";
            await _hub.Clients.All.SendAsync("NotificationAll", message);
            return CustomResponse(message);
        }
    }
}

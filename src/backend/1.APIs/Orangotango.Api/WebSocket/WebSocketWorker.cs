using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Orangotango.Business.WebSocket;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Orangotango.Api.WebSocket
{
    public class WebSocketWorker : BackgroundService
    {
        private readonly IHubContext<NotificationHub> _hub;
        public WebSocketWorker(IHubContext<NotificationHub> hub)
        {
            _hub = hub;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = $"Data: {DateTime.Now}";
                Console.WriteLine($"Enviando notificação: {message}");
                
                await _hub.Clients.All.SendAsync(NotificationHub.All, message, cancellationToken: stoppingToken);
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}

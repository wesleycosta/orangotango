using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Orangotango.Business.WebSocket
{
    public class NotificationHub : Hub
    {
        public static readonly string All = "NotificationAll";

        public override async Task OnConnectedAsync()
        {
           await ConnectToNotification(All);
        }

        public async Task ConnectToNotification(string symbol)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, symbol);
        }
    }
}

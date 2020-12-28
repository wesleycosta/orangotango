using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Orangotango.Business.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task ConnectToNotification(string symbol)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, symbol);
        }
    }
}

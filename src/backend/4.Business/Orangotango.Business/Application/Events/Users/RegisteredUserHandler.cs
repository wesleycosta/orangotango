using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Orangotango.Business.Application.Events.Users
{
    public class RegisteredUserHandler : INotificationHandler<RegisteredUserEvent>
    {
        public async Task Handle(RegisteredUserEvent notification, CancellationToken cancellationToken)
        {
            System.Console.WriteLine(notification);
            await Task.CompletedTask;
        }
    }
}

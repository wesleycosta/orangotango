using Microsoft.AspNetCore.Authorization;
using Orangotango.Core.Notifications;

namespace Orangotango.Api.Infrastructure.Controllers
{
    [Authorize("Bearer")]
    public class MainControllerWithBearer : MainController
    {
        protected MainControllerWithBearer(INotifier notifier) : base(notifier)
        {
        }
    }
}

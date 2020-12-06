using Microsoft.AspNetCore.Authorization;
using Orangotango.Core.Notifications;

namespace Orangotango.WebApiShared.Controllers
{
    [Authorize("Bearer")]
    public class MainControllerWithBearer : MainController
    {
        protected MainControllerWithBearer(INotifier notifier) : base(notifier)
        {
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Orangotango.Core.Notifications;
using Orangotango.Core.Notifications.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Orangotango.WebApiShared.Controllers
{
    public class MainController : Controller
    {
        #region PROPERTIES AND CONSTRUCTORS

        public readonly INotifier Notifier;

        protected MainController(INotifier notifier)
        {
            Notifier = notifier;
        }

        #endregion

        #region METHODS

        protected bool IsValid() =>
            !Notifier.HaveNotification();

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValid())
                return Ok(new
                {
                    success = true,
                    data = result
                });

            return BadRequest(new
            {
                success = false,
                errors = Notifier.GetNotifications().Select(n => n.Message)
            });
        }

        private async Task AddNotificationModelState(ModelStateDictionary modelState)
        {
            var notifications = await Task.FromResult(Notifier.GetNotifications());

            notifications.ForEach(n => modelState.AddModelError(string.Empty, n.Message));
        }

        protected async Task<ActionResult> CustomResponse(ModelStateDictionary modelState)
        {
            await AddNotificationModelState(modelState);

            if (!modelState.IsValid)
                NotifyErrorModelInvalid(modelState);

            return CustomResponse();
        }

        protected void NotifyErrorModelInvalid(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(errorMsg);
            }
        }

        protected void NotifyError(string message)
        {
            Notifier.Handle(new Notification(message));
        }

        #endregion
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Orangotango.Core.Notifications;
using Orangotango.Core.Notifications.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Orangotango.WebApiShared.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class MainController : ControllerBase
    {
        #region PROPERTIES AND CONSTRUCTORS

        private readonly INotifier _notifier;

        protected MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        #endregion

        #region METHODS

        protected bool IsValid() =>
            !_notifier.HaveNotification();

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
                errors = _notifier.GetNotifications().Select(n => n.Message)
            });
        }

        private async Task AddNotificationModelState(ModelStateDictionary modelState)
        {
            var notifications = await Task.FromResult(_notifier.GetNotifications());

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
            _notifier.Handle(new Notification(message));
        }

        #endregion
    }
}

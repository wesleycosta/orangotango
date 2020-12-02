using Orangotango.Core.Notifications.Model;
using System.Collections.Generic;

namespace Orangotango.Core.Notifications
{
    public interface INotifier
    {
        bool HaveNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
        void Notify(string message);
    }
}

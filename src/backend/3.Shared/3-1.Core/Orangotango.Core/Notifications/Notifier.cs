using Orangotango.Core.Notifications.Model;
using System.Collections.Generic;
using System.Linq;

namespace Orangotango.Core.Notifications
{
    internal class Notifier : INotifier
    {
        private readonly List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public bool HaveNotification()
        {
            return _notifications.Any();
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void Notify(string message)
        {
            Handle(new Notification(message));
        }
    }
}

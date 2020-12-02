namespace Orangotango.Core.Notifications.Model
{
    public class Notification
    {
        public string Message { get; }

        public Notification(string message)
        {
            Message = message;
        }
    }
}

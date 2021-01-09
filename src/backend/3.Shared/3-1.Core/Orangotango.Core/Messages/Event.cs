using System;
using MediatR;
using NSE.Core.Messages;

namespace Orangotango.Core.Messages
{
    public class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        public Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
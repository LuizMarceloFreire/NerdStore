using MediatR;
using System;

namespace NerdStore.Core.Messages
{
    public abstract class Event : Massage, INotification
    {
        public DateTime Timestamp { get; set; }

        public Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}

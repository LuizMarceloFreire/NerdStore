using System;

namespace NerdStore.Core.Messages
{
    public abstract class Massage
    {
        public string MessageType { get; set; }
        public Guid AggregateId { get; set; }

        public Massage()
        {
            MessageType = GetType().Name;
        }
    }
}

using NerdStore.Core.Messages;
using System;

namespace NerdStore.Core.Domain
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}

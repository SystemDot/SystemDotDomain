using System;

namespace SystemDot.EventSourcing.Sessions
{
    public class EventContainer
    {
        public EventContainer(Guid aggregateRootId, object @event)
        {
            AggregateRootId = aggregateRootId;
            Event = @event;
        }

        public Guid AggregateRootId { get; private set; }

        public object Event { get; private set; }
    }
}
using System;

namespace SystemDot.EventSourcing.Sessions
{
    public class EventContainer
    {
        public EventContainer(Guid aggregateRootId, SourcedEvent @event)
        {
            AggregateRootId = aggregateRootId;
            Event = @event;
        }

        public Guid AggregateRootId { get; private set; }

        public SourcedEvent Event { get; private set; }
    }
}
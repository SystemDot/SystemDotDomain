using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.EventSourcing.Dispatching;
using SystemDot.EventSourcing.Sessions;

namespace SystemDot.EventSourcing.InMemory
{
    public class InMemoryEventSession : EventSession
    {
        readonly List<EventContainer> events;

        public InMemoryEventSession(IEventDispatcher eventDispatcher) : base(eventDispatcher)
        {
            events = new List<EventContainer>();
        }

        public override IEnumerable<object> GetEvents(Guid streamId)
        {
            return events
                .Where(e => e.AggregateRootId == streamId)
                .Select(e => e.Event);
        }

        protected override void OnEventsCommitted()
        {
        }

        protected override void OnEventCommitting(EventContainer eventContainer)
        {
            events.Add(eventContainer);
        }

        public override IEnumerable<object> AllEvents()
        {
            return events.Select(c => c.Event);
        }
    }
}
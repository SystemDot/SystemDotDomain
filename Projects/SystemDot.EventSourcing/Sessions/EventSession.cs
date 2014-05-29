using System;
using System.Collections.Generic;
using SystemDot.Core;
using SystemDot.Core.Collections;
using SystemDot.EventSourcing.Dispatching;

namespace SystemDot.EventSourcing.Sessions
{
    public abstract class EventSession : Disposable, IEventSession
    {
        readonly IEventDispatcher eventDispatcher;
        readonly List<EventContainer> eventsToCommit;

        protected EventSession(IEventDispatcher eventDispatcher)
        {
            this.eventDispatcher = eventDispatcher;
            eventsToCommit = new List<EventContainer>();
        }

        public abstract IEnumerable<SourcedEvent> GetEvents(string streamId);

        public void StoreEvent(SourcedEvent @event, string aggregateRootId)
        {
            eventsToCommit.Add(new EventContainer(aggregateRootId, @event));
        }

        public void Commit()
        {
            eventsToCommit.ForEach(CommitEvent);
            OnEventsCommitted();
            eventsToCommit.Clear();
        }

        void CommitEvent(EventContainer @event)
        {
            eventDispatcher.Dispatch(@event.Event.Body);
            OnEventCommitting(@event);
        }

        protected abstract void OnEventsCommitted();

        protected abstract void OnEventCommitting(EventContainer eventContainer);

        public abstract IEnumerable<SourcedEvent> AllEvents();
    }
}
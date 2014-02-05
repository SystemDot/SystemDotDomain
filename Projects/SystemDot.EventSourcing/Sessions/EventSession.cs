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

        public abstract IEnumerable<object> GetEvents(Guid streamId);
        
        public void StoreEvent(object @event, Guid aggregateRootId, Type aggregateRootType)
        {
            eventsToCommit.Add(new EventContainer(aggregateRootId, @event));
        }

        public void Commit(Guid commandId)
        {
            eventsToCommit.ForEach(CommitEvent);
            OnEventsCommitted();
            eventsToCommit.Clear();
        }

        void CommitEvent(EventContainer @event)
        {
            eventDispatcher.Dispatch(@event.Event);
            OnEventCommitting(@event);
        }

        protected abstract void OnEventsCommitted();

        protected abstract void OnEventCommitting(EventContainer eventContainer);

        public abstract IEnumerable<object> AllEvents();
    }
}
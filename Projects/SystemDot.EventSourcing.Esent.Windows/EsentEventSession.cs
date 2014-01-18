using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;
using SystemDot.EventSourcing.Dispatching;
using SystemDot.EventSourcing.Sessions;

namespace SystemDot.EventSourcing.Esent.Windows
{
    public class EsentEventSession : IEventSession
    {
        readonly IEventDispatcher eventDispatcher;
        
        public EsentEventSession(IEventDispatcher eventDispatcher)
        {
            this.eventDispatcher = eventDispatcher;
        }

        public Guid CommandId { get; private set; }

        public IEnumerable<object> GetEvents(Guid aggregateRootId)
        {
            return Db.Db.GetById<List<Object>>(aggregateRootId);
        }

        public void StoreEvent(object @event, Guid aggregateRootId, Type aggregateRootType)
        {
            var events = GetEvents(aggregateRootId).ToList();
            events.Add(@event);
            Db.Db.Store(aggregateRootId, events);
        }

        public void Commit(Guid commandId)
        {
        }

        public void Dispose()
        {
        }

        public IEnumerable<object> AllEvents()
        {
            return null;
        }

   
        private class EventContainer
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
}
using System;
using SystemDot.EventSourcing.Sessions;

namespace SystemDot.Domain.Aggregation
{
    public abstract class AggregateRoot
    {
        public static EventHandler<EventSourceEventArgs> EventAdded;
        public EventHandler<EventSourceEventArgs> EventReplayed;
        
        readonly ConventionEventToHandlerRouter eventRouter;

        public Guid Id { get; private set; }

        protected AggregateRoot()
        {
            this.eventRouter = new ConventionEventToHandlerRouter(this, "ApplyEvent");
        }

        protected AggregateRoot(Guid id) : this()
        {
            Id = id;
        }

        protected internal void AddEvent(object @event)
        {
            ReplayEvent(@event);
            EventSessionProvider.Session.StoreEvent(CreateSourcedEvent(@event), Id);
        }

        SourcedEvent CreateSourcedEvent(object body)
        {
            var sourcedEvent = new SourcedEvent
            {
                Body = body
            };

            sourcedEvent.AddHeader(EventHeaderKeys.AggregateType, GetType());

            return sourcedEvent;
        }

        protected internal void AddEvent<T>(Action<T> initaliseEvent) where T : new()
        {
            var @event = new T();
            initaliseEvent(@event);
            AddEvent(@event);
        }

        public void ReplayEvent(object toReplay)
        {
            this.eventRouter.RouteEventToHandlers(toReplay);

            OnEventReplayed(toReplay);
        }

        void OnEventReplayed(object @event)
        {
            if (EventReplayed != null)
            {
                EventReplayed(this, new EventSourceEventArgs(@event));
            }
        }

        internal static void SetId(AggregateRoot aggregateRoot, Guid id)
        {
            aggregateRoot.Id = id;
        }
    }
}
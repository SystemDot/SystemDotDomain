using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;
using SystemDot.Core.Collections;
using SystemDot.EventSourcing.Sessions;
using EventStore;

namespace SystemDot.EventSourcing.Sql.Windows
{
    public class EventStoreEventSession : Disposable, IEventSession
    {
        readonly IStoreEvents eventStore;
        readonly Dictionary<Guid, IEventStream> streams;

        public EventStoreEventSession(IStoreEvents eventStore)
        {
            this.eventStore = eventStore;
            streams = new Dictionary<Guid, IEventStream>();
        }

        public IEnumerable<SourcedEvent> AllEvents()
        {
            return eventStore
                .Advanced
                .GetFrom(DateTime.MinValue)
                .SelectMany(e => e.Events)
                .Select(CreateSourcedEvent);
        }

        public IEnumerable<SourcedEvent> GetEvents(Guid streamId)
        {
            IEventStream stream = GetStream(streamId);

            return stream.CommittedEvents.Select(CreateSourcedEvent)
                .Concat(stream.UncommittedEvents.Select(CreateSourcedEvent));
        }

        SourcedEvent CreateSourcedEvent(EventMessage @from)
        {
            var @event = new SourcedEvent
            {
                Body = @from.Body
            };

            @from.Headers.ForEach(h => @event.Headers.Add(h.Key, h.Value));

            return @event;
        }

        public void StoreEvent(SourcedEvent @event, Guid aggregateRootId)
        {
            var uncommittedEvent = new EventMessage
            {
                Body = @event.Body
            };

            @event.Headers.ForEach(h => uncommittedEvent.Headers.Add(h.Key, h.Value));

            GetStream(aggregateRootId).Add(uncommittedEvent);
        }

        public void Commit(Guid commandId)
        {
            streams.ForEach(s => CommitStream(commandId, s.Value));
        }

        IEventStream GetStream(Guid aggregateRootId)
        {
            IEventStream stream;

            if (!streams.TryGetValue(aggregateRootId, out stream)) streams[aggregateRootId] = stream = eventStore.OpenStream(aggregateRootId, 0, int.MaxValue);

            return stream;
        }

        void CommitStream(Guid commandId, IEventStream toCommit)
        {
            try
            {
                toCommit.CommitChanges(commandId);
            }
            catch (DuplicateCommitException)
            {
                toCommit.ClearChanges();
            }
            catch (ConcurrencyException)
            {
                toCommit.ClearChanges();
                throw;
            }
        }

        protected override void DisposeOfManagedResources()
        {
            streams.ForEach(s => s.Value.Dispose());
            streams.Clear();

            base.DisposeOfManagedResources();
        }
    }
}
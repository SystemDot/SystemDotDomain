using System;
using System.Collections.Generic;

namespace SystemDot.EventSourcing.Sessions
{
    public interface IEventSession : IDisposable
    {
        IEnumerable<SourcedEvent> GetEvents(string streamId);

        void StoreEvent(SourcedEvent @event, string aggregateRootId);

        void Commit();

        IEnumerable<SourcedEvent> AllEvents();
    }
}
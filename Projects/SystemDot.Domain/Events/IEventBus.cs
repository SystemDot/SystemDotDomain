using System;

namespace SystemDot.Domain.Events
{
    public interface IEventBus
    {
        void PublishEvent<T>(Action<T> initaliseEventAction) where T : new();
        void PublishEvent<T>(T @event);
    }
}
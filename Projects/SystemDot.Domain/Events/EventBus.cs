using System;
using SystemDot.Messaging;

namespace SystemDot.Domain.Events
{
    public class EventBus : IEventBus
    {
        readonly IBus bus;

        public EventBus(IBus bus)
        {
            this.bus = bus;
        }

        public void PublishEvent<T>(Action<T> initaliseEventAction) where T : new()
        {
            var message = new T();
            initaliseEventAction(message);
            PublishEvent(message);
        }

        public void PublishEvent<T>(T @event)
        {
            bus.Publish(@event);
        }
    }
}
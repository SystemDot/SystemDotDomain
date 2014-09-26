namespace SystemDot.Domain.Events.Dispatching
{
    public class EventDispatcher : IEventDispatcher
    {
        readonly IEventBus bus;

        public EventDispatcher(IEventBus bus)
        {
            this.bus = bus;
        }

        public void Dispatch(object toDispatch)
        {
            bus.PublishEvent(toDispatch);
        }
    }
}
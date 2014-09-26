using SystemDot.ThreadMarshalling;

namespace SystemDot.Domain.Events.Dispatching
{
    public class UiThreadDispatchingEventDispatcher : IEventDispatcher
    {
        readonly IEventDispatcher inner;
        readonly IMainThreadMarshaller mainThreadDispatcher;

        public UiThreadDispatchingEventDispatcher(IEventDispatcher inner, IMainThreadMarshaller mainThreadDispatcher)
        {
            this.inner = inner;
            this.mainThreadDispatcher = mainThreadDispatcher;
        }

        public void Dispatch(object toDispatch)
        {
            mainThreadDispatcher.RunOnMainThread(() => inner.Dispatch(toDispatch));
        }
    }
}
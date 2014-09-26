namespace SystemDot.Domain.Events.Dispatching
{
    public interface IEventDispatcher
    {
        void Dispatch(object toDispatch);
    }
}
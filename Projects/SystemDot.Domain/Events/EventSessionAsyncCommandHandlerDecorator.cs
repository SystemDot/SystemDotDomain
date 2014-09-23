using System.Threading.Tasks;
using SystemDot.EventSourcing.Sessions;
using SystemDot.Messaging.Handling;

namespace SystemDot.Domain.Events
{
    public class EventSessionAsyncCommandHandlerDecorator<T> : IAsyncMessageHandler<T>
    {
        readonly IEventSessionFactory eventSessionFactory;
        readonly IAsyncMessageHandler<T> decorated;

        public EventSessionAsyncCommandHandlerDecorator(
            IEventSessionFactory eventSessionFactory, 
            IAsyncMessageHandler<T> decorated)
        {
            this.eventSessionFactory = eventSessionFactory;
            this.decorated = decorated;
        }

        public async Task Handle(T message)
        {
            using (var session = eventSessionFactory.Create())
            {
                await decorated.Handle(message);
                await session.CommitAsync();
            } 
        }
    }
}
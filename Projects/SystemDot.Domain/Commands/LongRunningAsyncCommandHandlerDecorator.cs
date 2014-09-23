using System.Threading.Tasks;
using SystemDot.Messaging.Handling;

namespace SystemDot.Domain.Commands
{
    public class LongRunningAsyncCommandHandlerDecorator<T> : IAsyncMessageHandler<T>
    {
        readonly IAsyncMessageHandler<T> decorated;

        public LongRunningAsyncCommandHandlerDecorator(IAsyncMessageHandler<T> decorated)
        {
            this.decorated = decorated;
        }

        public async Task Handle(T message)
        {
            await Task.Run(async () => await decorated.Handle(message));
        }
    }
}
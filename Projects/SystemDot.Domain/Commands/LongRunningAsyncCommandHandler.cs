using System.Threading.Tasks;

namespace SystemDot.Domain.Commands
{
    public class LongRunningAsyncCommandHandler<T> : IAsyncCommandHandler<T>
    {
        readonly IAsyncCommandHandler<T> decorated;

        public LongRunningAsyncCommandHandler(IAsyncCommandHandler<T> decorated)
        {
            this.decorated = decorated;
        }

        public async Task Handle(T message)
        {
            await Task.Run(() => decorated.Handle(message));
        }
    }
}
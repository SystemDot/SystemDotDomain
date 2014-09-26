using System.Threading.Tasks;
using SystemDot.AzureMobile;
using SystemDot.Domain.Commands;

namespace SystemDot.RelationalDataStore.AzureMobile
{
    public abstract class AzureDataContextAsyncCommandHandler<T> : IAsyncCommandHandler<T>
    {
        readonly IAsyncCommandHandler<T> inner;
        readonly DataContextLookup lookup;
        readonly string localDbName;

        protected AzureDataContextAsyncCommandHandler(
            IAsyncCommandHandler<T> inner, 
            DataContextLookup lookup, 
            string localDbName)
        {
            this.inner = inner;
            this.lookup = lookup;
            this.localDbName = localDbName;
        }

        public async Task Handle(T message)
        {
            DataContext.PushCurrent(lookup.Get(localDbName));
            await inner.Handle(message);
            DataContext.PopCurrent();
        }
    }
}
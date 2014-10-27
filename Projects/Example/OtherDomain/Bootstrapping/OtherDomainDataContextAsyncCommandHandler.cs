using SystemDot.Domain.Commands;
using SystemDot.RelationalDataStore.AzureMobile;

namespace OtherDomain.Bootstrapping
{
    public class OtherDomainDataContextAsyncCommandHandler<T> : AzureDataContextAsyncCommandHandler<T>
    {
        public OtherDomainDataContextAsyncCommandHandler(
            IAsyncCommandHandler<T> inner,
            DataContextLookup lookup)
            : base(inner, lookup, "OtherDomain")
        {
        }
    }
}
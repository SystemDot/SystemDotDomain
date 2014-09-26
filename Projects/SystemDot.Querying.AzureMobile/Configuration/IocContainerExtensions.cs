using SystemDot.Ioc;
using SystemDot.RelationalDataStore.Repositories;

namespace SystemDot.RelationalDataStore.AzureMobile.Configuration
{
    internal static class IocContainerExtensions
    {
        internal static void RegisterAzureMobileRelationalDataStore(this IIocContainer container)
        {
            container.RegisterInstance<IRepository, Repository>();
            container.RegisterInstance<DataContextLookup, DataContextLookup>();
        }
    }
}
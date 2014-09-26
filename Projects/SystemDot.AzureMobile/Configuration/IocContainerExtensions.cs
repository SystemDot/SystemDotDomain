using SystemDot.AzureMobile.Sync;
using SystemDot.Ioc;

namespace SystemDot.AzureMobile.Configuration
{
    internal static class IocContainerExtensions
    {
        public static void RegisterAzureMobile(this IIocContainer container)
        {
            container.RegisterInstance<SyncContextFactory, SyncContextFactory>();
            container.RegisterInstance<DataStoreContextFactory, DataStoreContextFactory>();
            container.RegisterInstance<DataContextFactory, DataContextFactory>();
        }
    }
}
using SystemDot.Ioc;
using SystemDot.RelationalDataStore.Repositories;

namespace SystemDot.RelationalDataStore.InMemory.Configuration
{
    internal static class IocContainerExtensions
    {
        internal static void RegisterInMemoryRelationalDataStore(this IIocContainer container)
        {
            container.RegisterInstance<IRepository, InMemoryRepository>();
        }
    }
}
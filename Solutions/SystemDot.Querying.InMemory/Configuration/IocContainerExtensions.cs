using SystemDot.Ioc;

namespace SystemDot.Querying.InMemory.Configuration
{
    internal static class IocContainerExtensions
    {
        internal static void RegisterInMemoryQuerying(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<InMemoryRepository>();
        }
    }
}
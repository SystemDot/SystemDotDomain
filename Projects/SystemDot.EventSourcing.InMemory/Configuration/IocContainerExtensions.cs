using SystemDot.EventSourcing.Sessions;
using SystemDot.Ioc;

namespace SystemDot.EventSourcing.InMemory.Configuration
{
    internal static class IocContainerExtensions
    {
        internal static void RegisterInMemoryEventSourcing(this IIocContainer container)
        {
            container.RegisterInstance<InMemoryEventSession, InMemoryEventSession>();
            container.RegisterInstance<IEventSessionFactory, InMemoryEventSessionFactory>();
        }
    }
}

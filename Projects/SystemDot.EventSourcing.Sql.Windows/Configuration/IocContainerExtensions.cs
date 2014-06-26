using SystemDot.EventSourcing.Sql.Windows.Lookups;
using SystemDot.Ioc;

namespace SystemDot.EventSourcing.Sql.Windows.Configuration
{
    public static class IocContainerExtensions
    {
        internal static void RegisterSqlWindowsEventSourcing(this IIocContainer container)
        {
            container.RegisterInstance<ILookupIdCache, LookupIdCache>();
            container.RegisterFromAssemblyOf<EventStoreEventSession>();
        }
    }
}

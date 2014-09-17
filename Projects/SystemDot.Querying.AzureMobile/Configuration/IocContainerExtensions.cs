using SystemDot.Ioc;

namespace SystemDot.Querying.AzureMobile.Configuration
{
    internal static class IocContainerExtensions
    {
        internal static void RegisterAzureMobileQuerying(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<QueryableRepository>();
        }
    }
}
using SystemDot.EventSourcing.Projections.Mapping;
using SystemDot.Ioc;

namespace App.Bootstrapping
{
    internal static class IocContainerExtensions
    {
        public static void RegisterTestApp(this IIocContainer container)
        {
            container.RegisterMultipleTypes()
                .FromAssemblyOf<EventSourcedThingListItem>()
                .ThatImplementOpenType(typeof(IReadModelMapper<>))
                .ByClass();
        }
    }
}
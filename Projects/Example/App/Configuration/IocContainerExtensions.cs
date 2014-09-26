using SystemDot.EventSourcing.Projections.Mapping;
using SystemDot.Ioc;
using Domain;

namespace App.Configuration
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
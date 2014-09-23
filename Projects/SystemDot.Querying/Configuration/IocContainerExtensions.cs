using System.Collections;
using System.Threading.Tasks;
using SystemDot.Ioc;
using SystemDot.Querying.Mapping;
using SystemDot.Querying.Repositories;

namespace SystemDot.Querying.Configuration
{
    internal static class IocContainerExtensions
    {
        public static void RegisterQuerying(this IIocContainer container)
        {
            container
                .RegisterMultipleTypes()
                .FromAssemblyOf<IQueryableRepository>()
                .AllTypes()
                .ByClassAndInterface();
        }

        public static async Task BuildReadModel(this IIocContainer container)
        {
            await container.Resolve<ReadModelBuilder>().BuildAsync(container.ResolveMappers());
        }

        static IEnumerable ResolveMappers(this IIocContainer container)
        {
            return container.ResolveMutipleTypes().ThatImplementOpenType(typeof(IReadModelMapper<>));
        }
    }
}
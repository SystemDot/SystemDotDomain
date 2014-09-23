using SystemDot.Ioc;
using SystemDot.Querying.Mapping;
using Domain;

namespace App.Configuration
{
    internal static class IocContainerExtensions
    {
        public static void RegisterTestApp(this IIocContainer container)
        {
            container.RegisterMultipleTypes()
                .FromAssemblyOf<VendorListItem>()
                .ThatImplementOpenType(typeof(IReadModelMapper<>))
                .ByClass();
        }
    }
}
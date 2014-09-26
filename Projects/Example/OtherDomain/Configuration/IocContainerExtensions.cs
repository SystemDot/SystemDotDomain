using SystemDot.Domain.Commands;
using SystemDot.Ioc;
using OtherDomain;

namespace Domain.Configuration
{
    public static class IocContainerExtensions
    {
        public static void RegisterOtherTestDomain(this IIocContainer container)
        {
            container.RegisterMultipleTypes()
                .FromAssemblyOf<ActivateCrudThing>()
                .ThatImplementOpenType(typeof(IAsyncCommandHandler<>))
                .ByInterface();
        }
    }
}
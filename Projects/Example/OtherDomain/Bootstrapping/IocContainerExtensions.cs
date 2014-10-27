using SystemDot.Domain.Commands;
using SystemDot.Ioc;

namespace OtherDomain.Bootstrapping
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
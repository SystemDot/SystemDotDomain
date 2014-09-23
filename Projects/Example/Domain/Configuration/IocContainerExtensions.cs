using SystemDot.Domain.Commands;
using SystemDot.Domain.Events;
using SystemDot.Ioc;

namespace Domain.Configuration
{
    internal static class IocContainerExtensions
    {
        public static void RegisterTestDomain(this IIocContainer container)
        {
            container.RegisterMultipleTypes()
                .FromAssemblyOf<ActivateVendor>()
                .ThatImplementOpenType(typeof(IAsyncCommandHandler<>))
                .ByInterface();

            container.DecorateMultipleTypes()
                .ThatImplementOpenType(typeof(IAsyncCommandHandler<>))
                .WithOpenTypeDecorator(typeof(EventSessionAsyncCommandHandlerDecorator<>));
        }
    }
}
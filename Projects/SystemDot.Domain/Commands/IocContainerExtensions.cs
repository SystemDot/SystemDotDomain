namespace SystemDot.Domain.Commands
{
    using SystemDot.Ioc;

    public static class IocContainerExtensions
    {
        public static void RegisterCommandHandlersFromAssemblyOf<T>(this IIocContainer container)
        {
            container.RegisterMultipleTypes()
                .FromAssemblyOf<T>()
                .ThatImplementOpenType(typeof(IAsyncCommandHandler<>))
                .ByInterface();
        }
    }
}
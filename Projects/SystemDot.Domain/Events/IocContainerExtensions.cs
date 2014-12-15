namespace SystemDot.Domain.Events
{
    using SystemDot.Ioc;

    public static class IocContainerExtensions
    {
        public static void RegisterEventHandlersFromAssemblyOf<T>(this IIocContainer container)
        {
            container
                .RegisterMultipleTypes()
                .FromAssemblyOf<T>()
                .ThatImplementOpenType(typeof(IAsyncEventHandler<>))
                .ByInterface();
        }
    }
}
namespace SystemDot.Domain.Queries
{
    using SystemDot.Ioc;

    public static class IocContainerExtensions
    {
        public static void RegisterQueryHandlersFromAssemblyOf<T>(this IIocContainer container)
        {
            container
                .RegisterMultipleTypes()
                .FromAssemblyOf<T>()
                .ThatImplementOpenType(typeof(IAsyncQueryHandler<,>))
                .ByInterface();
        }
    }
}
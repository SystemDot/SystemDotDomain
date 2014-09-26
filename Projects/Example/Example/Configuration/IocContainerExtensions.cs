using SystemDot.Ioc;

namespace Example.Configuration
{
    internal static class IocContainerExtensions
    {
        public static void RegisterExample(this IIocContainer container)
        {
            container.RegisterInstance<ExampleRunner, ExampleRunner>();
        }
    }
}
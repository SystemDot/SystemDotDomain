using SystemDot.Ioc;

namespace Example
{
    internal static class IocContainerExtensions
    {
        public static void RegisterExample(this IIocContainer container)
        {
            container.RegisterInstance<ExampleRunner, ExampleRunner>();
        }
    }
}
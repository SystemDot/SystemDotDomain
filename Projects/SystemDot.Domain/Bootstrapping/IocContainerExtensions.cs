using SystemDot.Domain.Commands;
using SystemDot.Domain.Events;
using SystemDot.Domain.Events.Dispatching;
using SystemDot.Ioc;
using SystemDot.Messaging;
using SystemDot.Messaging.Handling.Configuration;
using SystemDot.Messaging.Simple;

namespace SystemDot.Domain.Bootstrapping
{
    public static class IocContainerExtensions
    {
        public static void RegisterCommandHandlersWithMessenger(this IIocContainer container)
        {
            container.RegisterOpenTypeHandlersWithMessenger(typeof(IAsyncCommandHandler<>));
        }

        public static void RegisterEventHandlersWithMessenger(this IIocContainer container)
        {
            container.RegisterOpenTypeHandlersWithMessenger(typeof(IAsyncEventHandler<>));
        }

        public static void RegisterSimpleMessaging(this IIocContainer container)
        {
            container.RegisterInstance<IBus, DispatcherBus>();
        }

        public static void DecorateEventDispatcherWithUiThreadDispatching(this IIocContainer container)
        {
            container.RegisterDecorator<UiThreadDispatchingEventDispatcher, IEventDispatcher>();
        }

        public static void RegisterDomain(this IIocContainer container)
        {
            container.RegisterInstance<IEventDispatcher, EventDispatcher>();
            container.RegisterInstance<IEventBus, EventBus>();
            container.RegisterInstance<ICommandBus, CommandBus>();
        }
    }
}
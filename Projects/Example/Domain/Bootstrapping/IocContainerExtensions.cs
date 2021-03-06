﻿using SystemDot.Domain.Commands;
using SystemDot.EventSourcing;
using SystemDot.Ioc;

namespace Domain.Bootstrapping
{
    public static class IocContainerExtensions
    {
        public static void RegisterTestDomain(this IIocContainer container)
        {
            container.RegisterMultipleTypes()
                .FromAssemblyOf<ActivateEventSourcedThing>()
                .ThatImplementOpenType(typeof(IAsyncCommandHandler<>))
                .ByInterface();

            container.DecorateMultipleTypes()
                .FromAssemblyOf<ActivateEventSourcedThing>()
                .ThatImplementOpenType(typeof(IAsyncCommandHandler<>))
                .WithOpenTypeDecorator(typeof(EventSessionAsyncCommandHandler<>));

            container.RegisterDecorator<
                LongRunningAsyncCommandHandler<InvokeLongRunningProcess>,
                IAsyncCommandHandler<InvokeLongRunningProcess>>();
        }
    }
}
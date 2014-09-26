﻿using SystemDot.Configuration;
using SystemDot.EventSourcing.Configuration;

namespace SystemDot.EventSourcing.InMemory.Configuration
{
    public static class EventSourcingBuilderConfigurationExtensions
    {
        public static BuilderConfiguration PersistToMemory(this EventSourcingBuilderConfiguration config)
        {
            config.GetBuilderConfiguration().RegisterBuildAction(c => c.RegisterInMemoryEventSourcing());
            return config.GetBuilderConfiguration();
        }
    }
}
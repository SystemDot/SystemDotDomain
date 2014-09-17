using SystemDot.Configuration;
using SystemDot.Querying.Configuration;

namespace SystemDot.Querying.InMemory.Configuration
{
    public static class QueryingBuilderConfigurationExtensions
    {
        public static BuilderConfiguration PersistToMemory(this QueryingBuilderConfiguration config)
        {
            config.GetBuilderConfiguration().RegisterBuildAction(c => c.RegisterInMemoryQuerying());

            return config.GetBuilderConfiguration();
        }
    }
}

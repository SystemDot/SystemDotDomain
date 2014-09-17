using SystemDot.Configuration;

namespace SystemDot.Querying.Configuration
{
    public class QueryingBuilderConfiguration
    {
        readonly BuilderConfiguration config;

        public QueryingBuilderConfiguration(BuilderConfiguration config)
        {
            this.config = config;
        }

        public BuilderConfiguration GetBuilderConfiguration()
        {
            return config;
        }
    }
}
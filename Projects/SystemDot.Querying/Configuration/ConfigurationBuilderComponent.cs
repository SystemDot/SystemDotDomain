using SystemDot.Configuration;
using SystemDot.Ioc;
using SystemDot.Querying.Repositories;

namespace SystemDot.Querying.Configuration
{
    public class ConfigurationBuilderComponent : IConfigurationBuilderComponent
    {
        public void Configure(ConfigurationBuilder builder)
        {
            builder.RegisterBuildAction(c => c.RegisterFromAssemblyOf<IQueryableRepository>());
            builder.RegisterBuildAction(c => c.Resolve<ReadModelBuilder>().Build());
        }
    }
}
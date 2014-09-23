using System.Linq;
using SystemDot.Configuration;

namespace SystemDot.Querying.Configuration
{
    public class ConfigurationBuilderComponent : IConfigurationBuilderComponent
    {
        public void Configure(ConfigurationBuilder builder)
        {
            builder.RegisterBuildAction(c => c.RegisterQuerying());
            builder.RegisterBuildAction(async c => await c.BuildReadModel(), BuildOrder.VeryLate);
        }
    }
}
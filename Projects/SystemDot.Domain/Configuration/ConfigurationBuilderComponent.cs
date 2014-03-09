using SystemDot.Configuration;
using SystemDot.Ioc;

namespace SystemDot.Domain.Configuration
{
    public class ConfigurationBuilderComponent : IConfigurationBuilderComponent
    {
        public void Configure(ConfigurationBuilder builder)
        {
            builder.RegisterBuildAction(c => c.RegisterFromAssemblyOf<IDomainRepository>());
        }
    }    
}
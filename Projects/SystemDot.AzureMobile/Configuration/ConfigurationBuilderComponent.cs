using SystemDot.Configuration;

namespace SystemDot.AzureMobile.Configuration
{
    public class ConfigurationBuilderComponent : IConfigurationBuilderComponent
    {
        public void Configure(ConfigurationBuilder builder)
        {
            builder.RegisterBuildAction(c => c.RegisterAzureMobile());
        }
    }    
}
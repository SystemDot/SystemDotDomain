using SystemDot.Configuration;
using App.Configuration;
using OtherDomain.Configuration;

namespace Example.Configuration
{
    public class ExampleBuilderConfiguration
    {
        readonly BuilderConfiguration config;

        public ExampleBuilderConfiguration(BuilderConfiguration config)
        {
            this.config = config;
        }

        public BuilderConfiguration PersistToMemory()
        {
            return config
                .UseExampleOtherDomain()
                    .PersistToMemory()
                .UseExampleApp()
                    .PersistToMemory();
        }

        public BuilderConfiguration PersistToSql()
        {
            return config
                .UseExampleOtherDomain()
                    .PersistToSql()
                .UseExampleApp()
                    .PersistToSql();
        }
    }
}
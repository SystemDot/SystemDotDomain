using SystemDot.Bootstrapping;
using App.Bootstrapping;
using OtherDomain.Bootstrapping;

namespace Example.Bootstrapping
{
    public class ExampleBootstrapBuilderConfiguration
    {
        readonly BootstrapBuilderConfiguration config;

        public ExampleBootstrapBuilderConfiguration(BootstrapBuilderConfiguration config)
        {
            this.config = config;
        }

        public BootstrapBuilderConfiguration PersistToMemory()
        {
            return config
                .UseExampleOtherDomain()
                    .PersistToMemory()
                .UseExampleApp()
                    .PersistToMemory();
        }

        public BootstrapBuilderConfiguration PersistToSql()
        {
            return config
                .UseExampleOtherDomain()
                    .PersistToSql()
                .UseExampleApp()
                    .PersistToSql();
        }
    }
}
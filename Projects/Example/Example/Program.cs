using System;
using System.Threading.Tasks;
using SystemDot.Configuration;
using SystemDot.Domain.Configuration;
using SystemDot.EventSourcing.Configuration;
using SystemDot.EventSourcing.InMemory.Configuration;
using SystemDot.Ioc;
using SystemDot.Messaging.Handling.Actions;
using SystemDot.Querying.Configuration;
using SystemDot.Querying.InMemory.Configuration;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        static async Task MainAsync()
        {
            IIocContainer container = new IocContainer();

            Configure.SystemDot()
                .ResolveReferencesWith(container)
                .UseDomain()
                    .WithSimpleMessaging()
                .UseQuerying()
                    .PersistToMemory()
                .UseEventSourcing()
                    .PersistToMemory()
                    //.PersistToSql("EventStore")
                .UseExample()
                .Initialise();

            await container.Resolve<ExampleRunner>().RunAsync();
        }
    }
}

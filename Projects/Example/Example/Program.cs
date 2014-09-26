using System;
using System.Threading;
using System.Threading.Tasks;
using SystemDot.Configuration;
using SystemDot.Domain.Configuration;
using SystemDot.EventSourcing.Configuration;
using SystemDot.EventSourcing.InMemory.Configuration;
using SystemDot.Ioc;
using SystemDot.Messaging.Handling.Actions;
using SystemDot.RelationalDataStore.Configuration;
using SystemDot.RelationalDataStore.InMemory.Configuration;
using Example.Configuration;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync();

            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine("I am the unhindered UI thread");
            }
        }

        static async Task MainAsync()
        {
            IIocContainer container = new IocContainer();

            await Configure.SystemDot()
                .ResolveReferencesWith(container)
                .UseDomain()
                    .DispatchEventsOnUiThread()
                    .WithSimpleMessaging()
                .UseExample()
                    .PersistToMemory()
                    //.PersistToSql()
                .InitialiseAsync();

            await container.Resolve<ExampleRunner>().RunAsync();
        }
    }
}

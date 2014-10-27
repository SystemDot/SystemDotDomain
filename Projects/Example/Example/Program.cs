using System;
using System.Threading;
using System.Threading.Tasks;
using SystemDot.Bootstrapping;
using SystemDot.Domain.Bootstrapping;
using SystemDot.Ioc;
using Example.Bootstrapping;

namespace Example
{
    class Program
    {
        static Task main;

        static void Main(string[] args)
        {
            main = MainAsync();

            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                if (main.IsFaulted)
                {
                    Console.WriteLine("Exception occured {0}", main.Exception);
                    return;
                }
                Console.WriteLine("I am the unhindered UI thread");
            }
        }

        static async Task MainAsync()
        {
            IIocContainer container = new IocContainer();
            
            Bootstrap.Application()
                .ResolveReferencesWith(container)
                .UseDomain()
                .DispatchEventsOnUiThread()
                .WithSimpleMessaging()
                .UseExample()
                .PersistToMemory()
                //.PersistToSql()
                .Initialise();

            await container.Resolve<ExampleRunner>().RunAsync();
        }
    }
}

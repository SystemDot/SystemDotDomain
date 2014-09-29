using System;
using System.Threading;
using System.Threading.Tasks;
using SystemDot.Configuration;
using SystemDot.Domain.Configuration;
using SystemDot.Ioc;
using Example.Configuration;

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
            await MainAsyncInner();
            
           
        }

        static async Task MainAsyncInner()
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

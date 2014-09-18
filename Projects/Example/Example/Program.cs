using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemDot.Configuration;
using SystemDot.Domain.Commands;
using SystemDot.Domain.Configuration;
using SystemDot.EventSourcing.Configuration;
using SystemDot.EventSourcing.InMemory.Configuration;
using SystemDot.Ioc;
using SystemDot.Messaging.Handling.Actions;
using SystemDot.Messaging.Simple;
using SystemDot.Querying.Configuration;
using SystemDot.Querying.InMemory.Configuration;
using SystemDot.Querying.Repositories;
using App;
using Domain;

namespace Example
{
    class Program
    {
        static ActionSubscriptionToken<VendorActivated> token;

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
                .Initialise();

            token = Messenger.RegisterHandler<VendorActivated>(OnVendorActivated);
            
            var bus = container.Resolve<ICommandBus>();
            
            for (int i = 0; i < 900; i++)
                await bus.SendCommandAsync(new ActivateVendor { Name = "VendorMan" + i });

            List<VendorListItem> query = await container
                .Resolve<IQueryableRepository>()
                .Query<VendorListItem>()
                .ToListAsync();

            query.ForEach(i => Console.WriteLine(i.Name));

            Console.WriteLine("Running Test");
            Console.ReadLine();
        }

        static void OnVendorActivated(VendorActivated obj)
        {
            Console.WriteLine("Vendor activated");
        }
    }
}

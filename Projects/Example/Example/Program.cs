using System;
using System.Linq;
using SystemDot.Configuration;
using SystemDot.Domain.Configuration;
using SystemDot.EventSourcing.Configuration;
using SystemDot.EventSourcing.InMemory.Configuration;
using SystemDot.Ioc;
using SystemDot.Messaging.Handling.Actions;
using SystemDot.Messaging.Simple;
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
            IIocContainer container = new IocContainer();

            Configure.SystemDot()
                .ResolveReferencesWith(container)
                .UseDomain()
                    .WithSimpleMessaging()
                .UseEventSourcing()
                    .PersistToMemory()
                    //.PersistToSql("EventStore")
                .Initialise();

            token = Messenger.RegisterHandler<VendorActivated>(OnVendorActivated);

            for (int i = 0; i < 900000; i++)
                Messenger.Send(new ActivateVendor { Name = "VendorMan" + i });

            container.Resolve<IQueryableRepository>()
                .Query<VendorListItem>()
                .ToList()
                .ForEach(i => Console.WriteLine(i.Name));

            Console.WriteLine("Running Test");
            Console.ReadLine();
        }

        static void OnVendorActivated(VendorActivated obj)
        {
            Console.WriteLine("Vendor activated");
        }
    }
}

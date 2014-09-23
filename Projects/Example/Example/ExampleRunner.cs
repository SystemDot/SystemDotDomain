using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemDot.Domain.Commands;
using SystemDot.Messaging.Simple;
using SystemDot.Querying.Repositories;
using App;
using Domain;

namespace Example
{
    public class ExampleRunner
    {
        readonly ICommandBus bus;
        readonly IQueryableRepository repository;

        public ExampleRunner(ICommandBus bus, IQueryableRepository repository)
        {
            this.bus = bus;
            this.repository = repository;
        }

        public async Task RunAsync()
        {
            Messenger.RegisterHandler<VendorActivated>(OnVendorActivated);

            for (int i = 0; i < 900; i++)
                await bus.SendCommandAsync(new ActivateVendor { Name = "VendorMan" + i });

            List<VendorListItem> query = await repository
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
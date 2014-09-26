using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemDot.Domain.Commands;
using SystemDot.Messaging.Simple;
using SystemDot.RelationalDataStore.Repositories;
using App;
using Domain;
using OtherDomain;

namespace Example
{
    public class ExampleRunner
    {
        readonly ICommandBus bus;
        readonly IRepository repository;

        public ExampleRunner(ICommandBus bus, IRepository repository)
        {
            this.bus = bus;
            this.repository = repository;
        }

        public async Task RunAsync()
        {
            for (int i = 0; i < 900; i++)
            {
                await bus.SendCommandAsync(new ActivateEventSourcedThing { Name = "EventSourcedThing" + i });
                Console.WriteLine("EventSourcedThing {0} activated", i);
            }
                
            List<EventSourcedThingListItem> query = await repository
                .Query<EventSourcedThingListItem>()
                .OrderBy(t => t.Name)
                .ToListAsync();

            query.ForEach(i => Console.WriteLine(i.Name));


            for (int i = 0; i < 900; i++)
            {
                await bus.SendCommandAsync(new ActivateCrudThing { Name = "CrudThing" + i });
                Console.WriteLine("CrudThing {0} activated", i);
            }

            List<CrudThing> crudQuery = await repository
                .Query<CrudThing>()
                .OrderBy(t => t.Name)
                .ToListAsync();

            crudQuery.ForEach(i => Console.WriteLine(i.Name));

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Long running process {0} invoking", i);
                await bus.SendCommandAsync(new InvokeLongRunningProcess { Name = "LongRun" + i });
                Console.WriteLine("Long running process {0} completed", i);
            }

            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemDot.AzureMobile;

namespace SystemDot.RelationalDataStore.AzureMobile
{
    public class DataContextLookup
    {
        readonly DataContextFactory factory;
        readonly Dictionary<string, DataContext> contexts;

        public DataContextLookup(DataContextFactory factory)
        {
            this.factory = factory;
            contexts = new Dictionary<string, DataContext>();
        }

        public async Task InitialiseAndAddAsync(
            string azureServerUrl,
            string licenceKey,
            string localDbName,
            Action<TableDefiner> tableDefinitions)
        {
            var dataContext = await factory.MakeAsync(
                azureServerUrl, 
                licenceKey, 
                localDbName, 
                tableDefinitions);

            contexts.Add(localDbName, dataContext);
        }

        public DataContext Get(string localDbName)
        {
            return contexts[localDbName];
        }
    }
}
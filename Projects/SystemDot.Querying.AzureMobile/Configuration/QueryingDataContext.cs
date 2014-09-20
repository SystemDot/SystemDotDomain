using System;
using System.Threading.Tasks;
using SystemDot.AzureMobile;

namespace SystemDot.Querying.AzureMobile.Configuration
{
    public class QueryingDataContext
    {
        readonly DataContextFactory factory;

        public DataContext Current { get; private set; }

        public QueryingDataContext(DataContextFactory factory)
        {
            this.factory = factory;
        }

        public async Task InitialiseAsync(
            string azureServerUrl,
            string licenceKey,
            string localDbName,
            Action<TableDefiner> tableDefinitions)
        {
            Current = await factory.MakeAsync(azureServerUrl, licenceKey, localDbName, tableDefinitions);
        }
    }
}
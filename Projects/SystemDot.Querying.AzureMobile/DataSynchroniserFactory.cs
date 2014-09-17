using SystemDot.AzureMobile.Sync;
using SystemDot.Querying.AzureMobile.Configuration;

namespace SystemDot.Querying.AzureMobile
{
    public class DataSynchroniserFactory
    {
        readonly QueryingDataContext dataContext;

        public DataSynchroniserFactory(QueryingDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public DataSynchroniser Make()
        {
            return new DataSynchroniser(dataContext.Current.SyncContext);
        }
    }
}
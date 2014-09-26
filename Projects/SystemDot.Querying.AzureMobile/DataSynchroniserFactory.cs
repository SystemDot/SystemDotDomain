using SystemDot.AzureMobile;
using SystemDot.AzureMobile.Sync;

namespace SystemDot.RelationalDataStore.AzureMobile
{
    public class DataSynchroniserFactory
    {
        public DataSynchroniser Make()
        {
            return new DataSynchroniser(DataContext.Current.SyncContext);
        }
    }
}
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

namespace SystemDot.AzureMobile
{
    public class TableDefiner
    {
        readonly MobileServiceSQLiteStore store;

        public TableDefiner(MobileServiceSQLiteStore store)
        {
            this.store = store;
        }

        public TableDefiner DefineTable<T>()
        {
            store.DefineTable<T>();
            return this;
        }
    }
}
using Microsoft.WindowsAzure.MobileServices;

namespace SystemDot.AzureMobile.Sync
{
    public class SyncContextFactory
    {
        public MobileServiceClient Make(string applicationUrl, string applicationKey)
        {
            return new MobileServiceClient(applicationUrl, applicationKey);
        }
    }
}
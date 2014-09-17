using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json.Linq;

namespace SystemDot.AzureMobile.Sync
{
    public class MobileServiceSyncHandler : IMobileServiceSyncHandler
    {
        public Task OnPushCompleteAsync(MobileServicePushCompletionResult result)
        {
            return Task.FromResult(0);
        }

        public Task<JObject> ExecuteTableOperationAsync(IMobileServiceTableOperation operation)
        {
            return operation.ExecuteAsync();
        }
    }
}
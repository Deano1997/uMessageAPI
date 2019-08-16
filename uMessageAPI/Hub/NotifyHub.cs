using Microsoft.AspNetCore.SignalR;

namespace uMessageAPI.Hub
{
    public class NotifyHub : Hub<ITypedHubClient>
    {

        public void BroadcastMessage() {
            
        }

    }
}

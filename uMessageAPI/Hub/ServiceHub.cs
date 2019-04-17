using Microsoft.AspNetCore.SignalR;

namespace uMessageAPI.Hub
{
    public class ServiceHub : Hub<IServiceHubClient>
    {

        public void BroadcastMessage() {
            
        }

    }
}

using System.Threading.Tasks;

namespace uMessageAPI.Hub
{
    public interface IServiceHubClient
    {

        // TODO: Replace with actual methods required for our application
        Task BroadcastMessage(string type, string payload);

    }
}

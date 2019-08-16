using System.Threading.Tasks;

namespace uMessageAPI.Hub
{
    public interface ITypedHubClient {
        Task BroadcastMessage(string type);
    }
}

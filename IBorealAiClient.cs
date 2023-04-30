using System.Threading.Tasks;
using BorealAI.Client.Models;

namespace BorealAI.Client
{
    public interface IBorealAiClient
    {
        string SubscriptionId { get; }

        string ApiKey { get; }

        string EndPoint { get; }

        Task<BorealAiResponse> GetResponseAsync(BorealAiRequest request, string userId);

        Task<BorealAiResponse> GetResponseAsync(IBorealAiFluentRequest fluentRequest, string userId);
    }
}

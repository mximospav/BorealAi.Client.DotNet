using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BorealAI.Client.Models;
using Newtonsoft.Json;

namespace BorealAI.Client
{
    public class BorealAiClient : IBorealAiClient
    {
        public string SubscriptionId { get; }
        public string ApiKey { get; }
        public string EndPoint { get; }

        public BorealAiClient(string subscriptionId, string apiKey, string endPoint = "https://borealai.creativecloudlab.com/api/")
        {
            SubscriptionId = subscriptionId;
            ApiKey = apiKey;
            EndPoint = endPoint;

            client = new HttpClient();
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public BorealAiClient(string subscriptionId, string apiKey, HttpClient client)
        {
            SubscriptionId = subscriptionId;
            ApiKey = apiKey;
            EndPoint = client.BaseAddress.ToString();

            this.client = client;
            this.client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<BorealAiResponse> GetResponseAsync(BorealAiRequest request, string userId)
        {
            var endpoint = new Uri($"{EndPoint}subscriptions/{SubscriptionId}/responses/{userId}?api_key={ApiKey}");
            var response = client.PostAsync(
                endpoint,
                new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    "application/json"));

            var responseContent = await response.Result.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BorealAiResponse>(responseContent);
            return result;
        }

        public async Task<BorealAiResponse> GetResponseAsync(IBorealAiFluentRequest fluentRequest, string userId)
        {
            return await GetResponseAsync(fluentRequest.GetRequestBody(), userId);
        }

        private readonly HttpClient client;
    }
}

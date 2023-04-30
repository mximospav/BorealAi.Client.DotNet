using BorealAI.Client.Models;

namespace BorealAI.Client
{
    public interface IBorealAiFluentRequest
    {
        BorealAiRequest GetRequestBody();

        IBorealAiFluentRequest WithEntity(string entityName, string entityValue);

        IBorealAiFluentRequest WithContext(string contextName, string contextValue);

        IBorealAiFluentRequest WithOptionalContext(string contextName, string contextValue);
    }
}

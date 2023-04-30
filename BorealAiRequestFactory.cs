using BorealAI.Client.Requests;

namespace BorealAI.Client
{
    public static class BorealAiRequestFactory
    {
        public static IBorealAiFluentRequest FromIntent(string intentName) => new BorealAiRequestFromIntent(intentName);

        public static BorealAiRequestGreetings Greetings => new BorealAiRequestGreetings();
    }
}

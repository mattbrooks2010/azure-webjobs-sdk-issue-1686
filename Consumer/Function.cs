using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Consumer
{
    public static class Function
    {
        public static void Run(
            [ServiceBusTrigger("testqueue")]
            string message,
            ILogger logger)
        {
            logger.LogInformation($"Received: {message}");
        }
    }
}
using Microsoft.Azure.WebJobs;

namespace Consumer
{
    public static class Function
    {
        public static void Run(
            [ServiceBusTrigger("testqueue")]
            string message)
        {
            // No-op
        }
    }
}
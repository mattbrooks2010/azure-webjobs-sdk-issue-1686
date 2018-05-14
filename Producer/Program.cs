using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace Consumer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serviceBusConnectionString = args[0];
            var messageCount = int.Parse(args[1]);

            RunAsync(serviceBusConnectionString, messageCount)
                .GetAwaiter()
                .GetResult();
        }

        private static Task RunAsync(
            string serviceBusConnectionString,
            int messageCount)
        {
            Console.WriteLine($"Queuing {messageCount} message(s)");

            var client = new QueueClient(serviceBusConnectionString, "testqueue");

            var messages = Enumerable
                .Range(1, messageCount)
                .Select(msg => new Message
                {
                    ContentType = "text/plain",
                    Body = Encoding.UTF8.GetBytes(msg.ToString())
                })
                .ToList();

            return client.SendAsync(messages);
        }
    }
}
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;

namespace Consumer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cfg = new JobHostConfiguration
            {
#if DEBUG
                DashboardConnectionString = "UseDevelopmentStorage=true",
                StorageConnectionString = "UseDevelopmentStorage=true"
#endif
            };

            cfg.LoggerFactory = new LoggerFactory();
            cfg.LoggerFactory.AddConsole(LogLevel.Debug);

            cfg.UseServiceBus(new ServiceBusConfiguration
            {
#if DEBUG
                ConnectionString = args[0]
#endif
            });

            Console.WriteLine("Listening");

            new JobHost(cfg).RunAndBlock();
        }
    }
}
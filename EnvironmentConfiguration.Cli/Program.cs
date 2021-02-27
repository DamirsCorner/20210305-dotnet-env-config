using Microsoft.Extensions.Configuration;
using System;

namespace EnvironmentConfiguration.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environment}.json", true, true)
                .AddEnvironmentVariables();

            var configurationRoot = builder.Build();
            var appConfig = configurationRoot.GetSection(nameof(AppConfig)).Get<AppConfig>();

            Console.WriteLine(appConfig.Environment);
        }
    }
}

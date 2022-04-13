using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ElephantClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            BuildConfig(configurationBuilder);
            var config = configurationBuilder.Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .Enrich.FromLogContext() // => adds more information from the serilog context
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Starting");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddTransient<IApplication, Application>();

                    services.AddHttpClient<IElephantClient, ElephantClient>(config =>
                    {
                        config.BaseAddress = new Uri("https://elephant-api.herokuapp.com");
                    });
                })
                .UseSerilog()
                .Build();

            var application = ActivatorUtilities.CreateInstance<Application>(host.Services);
            await application.Run();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            // connect appsettings to application
            // The order of AddJsonFile does matter. The last will overwrite existing configs.
            // In our case the environment variable will overwrite existing configs.
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
            
        }
    }
}

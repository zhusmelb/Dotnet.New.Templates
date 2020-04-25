using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Zhusmelb.App
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((_, loggerConfig) => {
                    loggerConfig.WriteTo.Console();
                })
                .ConfigureServices((hostBuilderContext, services) => {
                    services.AddHostedService<StartupService>();
                });
    }
}

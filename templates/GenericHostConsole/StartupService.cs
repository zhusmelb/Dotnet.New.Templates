using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Zhusmelb.App
{
    public class StartupService : IHostedService
    {
        private readonly IHostApplicationLifetime _hostLifetime;
        private readonly IConfiguration _config;
        private readonly ILogger _logger;

        public StartupService(
            IHostApplicationLifetime hostLifetime
            , IHost host
            , IConfiguration config
            , ILogger<StartupService> logger)
        {
            _hostLifetime = hostLifetime ?? throw new ArgumentNullException(nameof(hostLifetime));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _logger = logger ?? new NullLogger<StartupService>();

            _hostLifetime.ApplicationStarted.Register(Main);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting {Worker}", nameof(StartupService));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping {Worker}", nameof(StartupService));
            return Task.CompletedTask;
        }

        private void Main()
        {
            _logger.LogInformation("Doing main action");
        }
    }
}
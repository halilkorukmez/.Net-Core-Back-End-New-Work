using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.DataContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api.Worker
{ 
        public class WorkerService : BackgroundService
        {
            private readonly ILogger<WorkerService> _logger;
            public static string ApiCommand { get; set; } = "no command";

            public WorkerService(ILogger<WorkerService> logger)
            {
                _logger = logger;
            }

            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Worker running at: {time}, command: {string}", DateTimeOffset.Now, ApiCommand);
                    await Task.Delay(50000, stoppingToken);
                }
            }
        }
    }

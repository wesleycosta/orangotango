using Microsoft.Extensions.Hosting;
using Orangotango.Business.Intefaces.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Orangotango.EmailWorker
{
    public class Worker : BackgroundService
    {
        private readonly IEmailIntegrationHandler _emailIntegrationHandler;

        public Worker(IEmailIntegrationHandler emailIntegrationHandler)
        {
            _emailIntegrationHandler = emailIntegrationHandler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _emailIntegrationHandler.Execute();

            while (!stoppingToken.IsCancellationRequested)
                await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
        }
    }
}

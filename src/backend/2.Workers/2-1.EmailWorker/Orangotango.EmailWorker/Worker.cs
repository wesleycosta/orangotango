using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orangotango.Business.Intefaces.Repositories;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Orangotango.EmailWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IUserRepository _userRepository;

        public Worker(ILogger<Worker> logger,
                      IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var users = await _userRepository.GetAll();
                _logger.LogInformation(JsonSerializer.Serialize(users));
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}

using Orangotango.Core.Services;
using System;
using System.Threading.Tasks;

namespace Orangotango.Business.Services
{
    public class LoggerService : ILoggerService
    {
        public async Task Error(Exception exception, string payload)
        {
            Console.WriteLine($"{DateTime.Now} {exception.Message}");
            Console.WriteLine($"{DateTime.Now} | {payload}");
            await Task.CompletedTask;
        }

        public Task Error(Exception exception)
        {
            return Task.CompletedTask;
        }
    }
}

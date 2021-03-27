using Orangotango.Core.Services;
using System;
using System.Threading.Tasks;

namespace Orangotango.Tests.Infrastructure.Fakes
{
    public class LoggerServiceFake : ILoggerService
    {
        public async Task Error(Exception exception)
        {
            await Task.CompletedTask;
        }

        public async Task Error(Exception exception, string payload)
        {
            await Task.CompletedTask;
        }
    }
}

using System;
using System.Threading.Tasks;

namespace Orangotango.Core.Services
{
    public interface ILoggerService
    {
        Task Error(Exception exception);
        Task Error(Exception exception, string payload);
    }
}

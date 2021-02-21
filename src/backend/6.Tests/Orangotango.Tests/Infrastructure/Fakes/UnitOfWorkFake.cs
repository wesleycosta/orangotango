using Orangotango.Core.Data;
using System.Threading.Tasks;

namespace Orangotango.Tests.Infrastructure.Fakes
{
    public class UnitOfWorkFake : IUnitOfWork
    {
        public Task<bool> Commit()
        {
            return Task.FromResult(true);
        }
    }
}

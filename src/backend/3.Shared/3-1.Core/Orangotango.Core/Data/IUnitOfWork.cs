using System.Threading.Tasks;

namespace Orangotango.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
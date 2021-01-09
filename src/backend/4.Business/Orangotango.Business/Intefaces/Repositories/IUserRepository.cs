using Orangotango.Business.Models;
using Orangotango.Business.Models.ValueObjects;
using System.Threading.Tasks;

namespace Orangotango.Business.Intefaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetUserByEmail(Email email);
    }
}

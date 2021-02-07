using Orangotango.Business.Models;
using Orangotango.Business.Models.ValueObjects;
using System.Threading.Tasks;

namespace Orangotango.Business.Intefaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<bool> HasEmail(Email email);
        Task<User> GetUserByEmail(Email email);
        Task<User> GetByEmailAndPassword(Email email, string password);
    }
}

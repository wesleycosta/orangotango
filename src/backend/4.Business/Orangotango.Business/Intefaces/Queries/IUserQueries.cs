using Orangotango.Business.ViewModels;
using System.Threading.Tasks;

namespace Orangotango.Business.Intefaces.Queries
{
    public interface IUserQueries
    {
        Task<UserViewModel> GetUserByEmail(string email);
    }
}

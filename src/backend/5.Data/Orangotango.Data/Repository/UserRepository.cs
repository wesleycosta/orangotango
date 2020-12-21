using Microsoft.EntityFrameworkCore;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;
using Orangotango.Business.Models.DomainObjects;
using Orangotango.Data.Context;
using System.Threading.Tasks;

namespace Orangotango.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(OrangotangoContext db) : base(db)
        {
        }

        public async Task<User> GetUserByEmail(Email email)
        {
            return await _dbSet.AsNoTracking()
                               .FirstOrDefaultAsync(p => p.Email.Equals(email));
        }
    }
}

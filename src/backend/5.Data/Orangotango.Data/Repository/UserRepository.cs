using MongoDB.Driver;
using Orangotango.Business.Intefaces.Infrastructure;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;
using Orangotango.Business.Models.ValueObjects;
using System.Threading.Tasks;

namespace Orangotango.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IMongoContext db) : base(db)
        {
        }

        public async Task<User> GetUserByEmail(Email email)
        {
            var data = await _dbSet.FindAsync(Builders<User>.Filter.Eq("email.address", email.Address));
            return await data.FirstOrDefaultAsync();
        }
    }
}

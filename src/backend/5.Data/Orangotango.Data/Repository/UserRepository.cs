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
            var data = await DbSet.FindAsync(Filter.Eq("email.address", email.Address));
            return await data.FirstOrDefaultAsync();
        }

        public async Task<User> GetByEmailAndPassword(Email email, string password)
        {
            var data = await DbSet.FindAsync(Filter.And(Filter.Eq("email.address", email.Address),
                                                        Filter.Eq("password.hash", password)));

            return await data.FirstOrDefaultAsync();
        }

        public async Task<bool> ExistsWithSameEmail(Email email)
        {
            var data = await DbSet.FindAsync(Filter.Eq("email.address", email.Address));
            var user = await data.FirstOrDefaultAsync();
            return user != null;
        }
    }
}

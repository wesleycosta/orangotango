using MongoDB.Driver;
using Orangotango.Business.Intefaces.Infrastructure;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;
using Orangotango.Business.Models.ValueObjects;
using Orangotango.Data.Extensions;
using System.Threading.Tasks;

namespace Orangotango.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IMongoContext db) : base(db)
        {
        }

        public async Task<bool> HasEmail(Email email)
        {
            return await DbSet.AnyAsync(Filter.Where(user => user.Email.Equals(email) && user.Active));
        }

        public async Task<User> GetUserByEmail(Email email)
        {
            return await DbSet.FirstOrDefaultAsync(Filter.Where(user => user.Email.Equals(email)));
        }

        public async Task<User> GetByEmailAndPassword(Email email, string password)
        {
            return await DbSet.FirstOrDefaultAsync(Filter.Where(user => user.Email.Equals(email) &&
                                                                        user.Password.Hash.Equals(password) &&
                                                                        user.Active));
        }
    }
}

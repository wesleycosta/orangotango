using Orangotango.Business.Intefaces.Infrastructure;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;
using Orangotango.Data.Extensions;
using System.Threading.Tasks;

namespace Orangotango.Data.Repository
{
    public class RoomTypeRepository : Repository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(IMongoContext db) : base(db)
        {
        }

        public async Task<bool> HasName(string name)
        {
            return await DbSet.AnyAsync(Filter.Where(roomType => roomType.Name.Equals(name) && roomType.Active));
        }
    }
}

using Orangotango.Business.Intefaces.Infrastructure;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;

namespace Orangotango.Data.Repository
{
    public class RoomTypeRepository : Repository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(IMongoContext db) : base(db)
        {
        }
    }
}

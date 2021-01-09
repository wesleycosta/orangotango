using Orangotango.Business.Intefaces.Infrastructure;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;

namespace Orangotango.Data.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(IMongoContext db) : base(db)
        {
        }
    }
}

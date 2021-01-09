using Orangotango.Business.Intefaces.Infrastructure;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;

namespace Orangotango.Data.Repository
{
    public class HouseGuestRepository : Repository<HouseGuest>, IHouseGuestRepository
    {
        public HouseGuestRepository(IMongoContext db) : base(db)
        {
        }
    }
}

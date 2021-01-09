using Orangotango.Business.Intefaces.Infrastructure;
using Orangotango.Business.Intefaces.Repositories;
using Orangotango.Business.Models;

namespace Orangotango.Data.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(IMongoContext db) : base(db)
        {
        }
    }
}

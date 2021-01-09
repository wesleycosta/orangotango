using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.DomainObjects;
using System;

namespace Orangotango.Business.Models
{
    public class Booking : Entity
    {
        public DateRangeBooking DateRangeBooking { get; set; }
        public decimal Value { get; set; }
        public BookingStatusType Status { get; set; }

        public Guid RoomId { get; set; }
        public Guid HouseGuestId { get; set; }
    }
}

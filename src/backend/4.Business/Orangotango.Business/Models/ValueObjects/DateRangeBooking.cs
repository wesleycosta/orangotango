using Orangotango.Core.DomainObjects;
using System;

namespace Orangotango.Business.Models.ValueObjects
{
    public class DateRangeBooking
    {
        public static readonly DateTime MinValue = new DateTime(1900, 1, 1);

        public DateTime CheckInDate { get; private set; }
        public DateTime CheckOutDate { get; private set; }

        public DateRangeBooking(DateTime checkInDate, DateTime checkOutDate)
        {
            if (!IsValidDate(checkInDate))
                throw new DomainException("CheckInDate is invalid");

            if (!IsValidDate(checkOutDate))
                throw new DomainException("CheckOutDate is invalid");

            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }

        public static bool IsValid(DateTime checkInDate, DateTime checkOutDate)
        {
            return IsValidDate(checkInDate) && IsValidDate(checkOutDate);
        }

        private static bool IsValidDate(DateTime date)
        {
            return date > MinValue;
        }

        public override bool Equals(object obj)
        {
            if (obj is not DateRangeBooking date)
                return false;

            return CheckInDate.Date.Equals(date.CheckInDate.Date) && CheckOutDate.Date.Equals(date.CheckOutDate.Date);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + CheckInDate.GetHashCode();
        }

        public override string ToString()
        {
            return $"{CheckInDate} of {CheckOutDate}";
        }
    }
}
using Orangotango.Core.DomainObjects;
using System;

namespace Orangotango.Business.Models.ValueObjects
{
    public class DateRangeBooking
    {
        public static readonly DateTime MinValue = new DateTime(1900, 1, 1);

        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }

        public DateRangeBooking(DateTime checkIn, DateTime checkOut)
        {
            if (!IsValidDate(checkIn))
                throw new DomainException("CheckInDate is invalid");

            if (!IsValidDate(checkOut))
                throw new DomainException("CheckOutDate is invalid");

            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public static bool IsValid(DateTime checkIn, DateTime checkOut)
        {
            return IsValidDate(checkIn) && IsValidDate(checkOut);
        }

        private static bool IsValidDate(DateTime date)
        {
            return date > MinValue;
        }

        public override bool Equals(object obj)
        {
            if (obj is not DateRangeBooking date)
                return false;

            return CheckIn.Date.Equals(date.CheckIn.Date) && CheckOut.Date.Equals(date.CheckOut.Date);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + CheckIn.GetHashCode() + CheckOut.GetHashCode();
        }

        public override string ToString()
        {
            return $"{CheckIn.Date} of {CheckOut.Date}";
        }
    }
}
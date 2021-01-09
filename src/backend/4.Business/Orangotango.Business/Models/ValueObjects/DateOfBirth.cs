using Orangotango.Core.DomainObjects;
using System;

namespace Orangotango.Business.Models.ValueObjects
{
    public class DateOfBirth
    {
        public static readonly DateTime MinValue = new DateTime(1900, 1, 1);

        public DateTime Birthday { get; set; }

        public DateOfBirth(DateTime birthday)
        {
            if (!IsValid(birthday))
                throw new DomainException("Birthday invalid");

            Birthday = birthday;
        }

        public static bool IsValid(DateTime birthday)
        {
            return birthday > MinValue && birthday <= DateTime.UtcNow.AddYears(-18);
        }

        public override bool Equals(object obj)
        {
            if (obj is not DateOfBirth date)
                return false;

            return Birthday.Date.Equals(date.Birthday);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Birthday.GetHashCode();
        }

        public override string ToString()
        {
            return Birthday.ToString();
        }
    }
}
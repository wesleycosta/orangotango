using Orangotango.Core.DomainObjects;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Orangotango.Business.Models.ValueObjects
{
    public class Password
    {
        public static readonly byte MinLength = 6;
        public string Hash { get; set; }
        public DateTime Created { get; set; }

        public Password(string value)
        {
            if (!IsValid(value))
                throw new DomainException("Password invalid");

            Hash = value;
            Created = DateTime.UtcNow;
        }

        public string CreateHash()
        {
            Hash = CreateHash(Hash);
            return Hash;
        }

        public static string CreateHash(string password)
        {
            using var sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            var builder = new StringBuilder();

            foreach (var number in bytes)
                builder.Append(number.ToString("x2"));

            return builder.ToString();
        }

        public static bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < MinLength)
                return false;

            return Regex.IsMatch(value, @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$");
        }

        public override bool Equals(object obj)
        {
            if (obj is not Password password)
                return false;

            return Hash.Equals(password.Hash);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Hash.GetHashCode();
        }

        public override string ToString()
        {
            return Hash;
        }
    }
}

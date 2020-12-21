using Orangotango.Core.DomainObjects;
using System.Text.RegularExpressions;

namespace Orangotango.Business.Models.DomainObjects
{
    public class Email
    {
        public const int MAX_LENGTH = 254;
        public const int MIN_LENGTH = 5;
        public string EmailAddress { get; private set; }

        public Email(string emailAddress)
        {
            if (!IsValid(emailAddress))
                throw new DomainException("E-mail inválido");

            EmailAddress = emailAddress;
        }

        public static bool IsValid(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Email email)
                return false;

            return email.EmailAddress.Equals(EmailAddress);
        }
    }
}
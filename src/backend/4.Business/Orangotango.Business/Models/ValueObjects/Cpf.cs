using NetDevPack.Utilities;
using NetDevPackBr.Documentos.Validacao;
using Orangotango.Core.DomainObjects;
using System;

namespace Orangotango.Business.Models.ValueObjects
{
    public class Cpf
    {
        public static readonly byte Length = 11;
        public string Number { get; private set; }

        public Cpf(string number)
        {
            if (!IsValid(number))
                throw new DomainException("CPF is invalid");

            Number = number.OnlyNumbers(number);
        }

        public static bool IsValid(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            return new CpfValidador(cpf).EstaValido();
        }

        public string Format()
        {
            const string pattern = @"{0:000\.000\.000\-00}";
            return string.Format(pattern, Convert.ToUInt64(Number));
        }

        public override bool Equals(object obj)
        {
            if (obj is not Cpf email)
                return false;

            return email.Number.Equals(Number);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Number.GetHashCode();
        }

        public override string ToString()
        {
            return Number;
        }
    }
}
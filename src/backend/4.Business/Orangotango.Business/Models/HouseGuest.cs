using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.DomainObjects;
using System;

namespace Orangotango.Business.Models
{
    public class HouseGuest : Entity
    {
        public string Name { get; set; }
        public Email Email { get; set; }
        public Cpf Cpf { get; set; }
        public DateOfBirth DateOfBirth { get; set; }
    }
}

using Orangotango.Business.Models.DomainObjects;
using Orangotango.Core.DomainObjects;

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

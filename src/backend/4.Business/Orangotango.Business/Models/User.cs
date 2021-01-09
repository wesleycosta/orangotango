using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.DomainObjects;

namespace Orangotango.Business.Models
{
    public class User : Entity
    {
        public string Name { get; init; }
        public Email Email { get; init; }
        public string Password { get; private set; }
    }
}

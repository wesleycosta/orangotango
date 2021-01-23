using Orangotango.Business.Models.Types;
using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.Messages;

namespace Orangotango.Business.Application.Events.Users
{
    public class RegisteredUserEvent : Event
    {
        public string Name { get; init; }
        public Email Email { get; init; }
        public EmailTemplateType Type { get; init; }

        public override string ToString()
        {
            return $"{Name} | {Email}";
        }
    }
}

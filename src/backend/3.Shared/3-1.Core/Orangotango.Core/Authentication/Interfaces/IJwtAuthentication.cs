using Orangotango.Core.Authentication.Models;

namespace Orangotango.Core.Authentication.Interfaces
{
    public interface IJwtAuthentication
    {
        public string GenareteToken(UserAuthViewModel user);
    }
}

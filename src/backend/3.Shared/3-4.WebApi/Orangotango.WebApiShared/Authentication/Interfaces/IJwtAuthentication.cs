using Orangotango.WebApiShared.Authentication.ViewModels;

namespace Orangotango.WebApiShared.Authentication.Interfaces
{
    public interface IJwtAuthentication
    {
        public string GenareteToken(UserAuthViewModel user);
    }
}

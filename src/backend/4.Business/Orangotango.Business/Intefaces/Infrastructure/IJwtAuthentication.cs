using Orangotango.Business.ViewModels.Users;

namespace Orangotango.Business.Intefaces.Infrastructure
{
    public interface IJwtAuthentication
    {
        string GenerateToken(UserAuthViewModel user);
    }
}

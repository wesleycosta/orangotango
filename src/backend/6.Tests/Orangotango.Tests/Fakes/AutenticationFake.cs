using Orangotango.Business.Intefaces.Infrastructure;
using Orangotango.Business.ViewModels.Users;

namespace Orangotango.Tests.Fakes
{
    public class AutenticationFake : IJwtAuthentication
    {
        public string GenerateToken(UserAuthViewModel user)
        {
            return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
        }
    }
}

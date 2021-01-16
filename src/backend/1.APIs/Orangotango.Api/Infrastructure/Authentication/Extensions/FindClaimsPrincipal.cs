using Orangotango.Api.Infrastructure.Authentication.Configurations;
using System.Security.Claims;

namespace Orangotango.Api.Infrastructure.Authentication.Extensions
{
    public static class FindClaimsPrincipal
    {
        public static Claim FindFirst(this ClaimsPrincipal claims, ClaimJwtType type)
        {
            return claims.FindFirst(type.ToString());
        }
    }
}

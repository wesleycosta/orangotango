using Orangotango.Api.Infrastructure.Authentication.Extensions;
using Orangotango.Api.Infrastructure.Authentication.Configurations;
using System;
using System.Security.Claims;

namespace Orangotango.Api.Infrastructure.Authentication.User
{
    internal static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(null, nameof(principal));

            var claim = principal.FindFirst(ClaimJwtType.UserId);
            return claim?.Value;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(null, nameof(principal));

            var claim = principal.FindFirst(ClaimJwtType.UserEmail);
            return claim?.Value;
        }

        public static string GetUserToken(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(null, nameof(principal));

            var claim = principal.FindFirst(ClaimJwtType.UserToken);
            return claim?.Value;
        }

        public static string GetUserRefreshToken(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(null, nameof(principal));

            var claim = principal.FindFirst(ClaimJwtType.UserRefreshToken);
            return claim?.Value;
        }
    }
}
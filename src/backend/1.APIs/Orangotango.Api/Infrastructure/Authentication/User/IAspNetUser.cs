using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Orangotango.Api.Infrastructure.Authentication.User
{
    public interface IAspNetUser
    {
        string Name { get; }
        Guid GetUserId();
        string GetEmail();
        string GetToken();
        string GetRefreshToken();
        bool IsAuthenticated();
        bool HasRole(string role);
        IEnumerable<Claim> GetClaims();
        HttpContext GetHttpContext();
    }
}
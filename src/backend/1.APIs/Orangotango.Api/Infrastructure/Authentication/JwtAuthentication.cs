using Microsoft.IdentityModel.Tokens;
using Orangotango.Api.Infrastructure.Authentication.Configurations;
using Orangotango.Business.Intefaces.Infrastructure;
using Orangotango.Business.ViewModels.Users;
using Orangotango.Core.Settings;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Orangotango.Api.Infrastructure.Authentication
{
    internal class JwtAuthentication : IJwtAuthentication
    {
        private readonly AppSettings _appSettings;

        public JwtAuthentication(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        #region METHODS

        public string GenerateToken(UserAuthViewModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.JwtSettings.Issuer,
                Audience = _appSettings.JwtSettings.Audience,
                Subject = GetClaims(user),
                Expires = DateTime.UtcNow.AddHours(_appSettings.JwtSettings.Hours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_appSettings.JwtSettings.Key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }

        private static ClaimsIdentity GetClaims(UserAuthViewModel user) =>
            new ClaimsIdentity
            (
                new[] {
                    CreateClaim(ClaimJwtType.UserId, user.Id),
                    CreateClaim(ClaimJwtType.UserEmail, user.Email)
                }
            );

        private static Claim CreateClaim(ClaimJwtType type, object value) =>
            new Claim(type.ToString(), value.ToString());

        #endregion
    }
}

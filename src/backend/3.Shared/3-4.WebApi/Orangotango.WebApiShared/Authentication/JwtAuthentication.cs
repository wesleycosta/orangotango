using Microsoft.IdentityModel.Tokens;
using Orangotango.Core.Settings;
using Orangotango.WebApiShared.Authentication.Interfaces;
using Orangotango.WebApiShared.Authentication.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Orangotango.WebApiShared.Authentication
{
    internal class JwtAuthentication : IJwtAuthentication
    {
        private readonly AppSettings _appSettings;

        public JwtAuthentication(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }


        #region METHODS

        public string GenareteToken(UserAuthViewModel user)
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

        private static ClaimsIdentity GetClaims(UserAuthViewModel user) => new ClaimsIdentity
            (
                new GenericIdentity(user.Id.ToString(), "Id"),
                new[] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.NameId, user.Name),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email)
                }
            );

        #endregion
    }
}

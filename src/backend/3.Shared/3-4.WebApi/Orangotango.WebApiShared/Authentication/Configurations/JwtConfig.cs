using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Orangotango.Core.Settings;

namespace Orangotango.WebApiShared.Authentication.Configurations
{
    public static class JwtConfig
    {
        public static IServiceCollection AddJwtConfig(this IServiceCollection services, AppSettings appSettings)
        {
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            services.AddAuthentication(p =>
            {
                p.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                p.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(p =>
            {
                p.RequireHttpsMetadata = true;
                p.SaveToken = true;
                p.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(appSettings.JwtSettings.Key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.JwtSettings.Audience,
                    ValidIssuer = appSettings.JwtSettings.Issuer
                };
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            return services;
        }
    }
}

using Orangotango.Core.Settings;
using System;

namespace Orangotango.DependencyInjection
{
    public static class EnvironmentConfig
    {
        public static AppSettings Builder()
        {
            return new AppSettings
            {
                ConnectionString = Environment.GetEnvironmentVariable("ConnectionString"),
                Environment = (EnvironmentType)Enum.Parse(typeof(EnvironmentType), Environment.GetEnvironmentVariable("Environment")),
                JwtSettings = GetJwtSettings()
            };
        }

        private static JwtSettings GetJwtSettings()
        {
            return new JwtSettings
            {
                Audience = Environment.GetEnvironmentVariable("Jwt.Audience"),
                Hours = int.Parse(Environment.GetEnvironmentVariable("Jwt.Hours")),
                Issuer = Environment.GetEnvironmentVariable("Jwt.Issuer"),
                Secret = Environment.GetEnvironmentVariable("Jwt.Secret")
            };
        }
    }
}

using Orangotango.Core.Settings;
using System;

namespace Orangotango.DependencyInjection
{
    public static class EnvironmentConfig
    {
        public static AppSettings Builder()
        {
            var env = (EnvironmentType)Enum.Parse(typeof(EnvironmentType), Environment.GetEnvironmentVariable("ENVIRONMENT"));
            var database = $"{Environment.GetEnvironmentVariable("DATABASE")}_{env}".ToLower();

            return new AppSettings
            {
                ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING"),
                DataBase = database,
                Environment = env,
                Origins = Environment.GetEnvironmentVariable("CORS_ORIGINS"),
                JwtSettings = GetJwtSettings(),
                LoggerSettings = GetLoggerSettings()
            };
        }

        private static JwtSettings GetJwtSettings()
        {
            return new JwtSettings
            {
                Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                Hours = int.Parse(Environment.GetEnvironmentVariable("JWT_HOURS")),
                Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
                Secret = Environment.GetEnvironmentVariable("JWT_SECRET")
            };
        }

        private static LoggerSettings GetLoggerSettings()
        {
            return new LoggerSettings
            {
                ElasticSearchStringConnection = Environment.GetEnvironmentVariable("LOGGER_STRING_CONNECTION")
            };
        }
    }
}

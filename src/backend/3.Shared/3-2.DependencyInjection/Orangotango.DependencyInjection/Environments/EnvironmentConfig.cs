using Orangotango.Core.Settings;
using System;

namespace Orangotango.DependencyInjection
{
    public static class EnvironmentConfig
    {
        public static AppSettings Builder()
        {
            var env = (EnvironmentType)Enum.Parse(typeof(EnvironmentType), Environment.GetEnvironmentVariable("Environment"));
            var database = $"{Environment.GetEnvironmentVariable("DataBase")}_{env}".ToLower();

            return new AppSettings
            {
                ConnectionString = Environment.GetEnvironmentVariable("ConnectionString"),
                DataBase = database,
                Environment = env,
                JwtSettings = GetJwtSettings(),
                LoggerSettings = GetLoggerSettings()
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

        // TODO
        private static LoggerSettings GetLoggerSettings()
        {
            return new LoggerSettings
            {
                ElasticSearchStringConnection = "http://localhost:9200/"
            };
        }
    }
}

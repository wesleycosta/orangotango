using Orangotango.Core.Settings;
using Orangotango.DependencyInjection.Environments;
using System;

namespace Orangotango.DependencyInjection
{
    public static class EnvironmentConfig
    {
        public static AppSettings Builder()
        {
            var env = (EnvironmentType)Enum.Parse(typeof(EnvironmentType), EnvironmentReader.GetEnvironmentVariable("ENVIRONMENT"));
            var database = $"{EnvironmentReader.GetEnvironmentVariable("DATABASE")}_{env}".ToLower();

            return new AppSettings
            {
                ConnectionString = EnvironmentReader.GetEnvironmentVariable("CONNECTION_STRING"),
                DataBase = database,
                Environment = env,
                Origins = EnvironmentReader.GetEnvironmentVariable("CORS_ORIGINS"),
                JwtSettings = GetJwtSettings(),
                LoggerSettings = GetLoggerSettings(),
                RabbitMQSettings = GetRabbitMQSettings()
            };
        }

        private static JwtSettings GetJwtSettings()
        {
            return new JwtSettings
            {
                Audience = EnvironmentReader.GetEnvironmentVariable("JWT_AUDIENCE"),
                Hours = int.Parse(EnvironmentReader.GetEnvironmentVariable("JWT_HOURS")),
                Issuer = EnvironmentReader.GetEnvironmentVariable("JWT_ISSUER"),
                Secret = EnvironmentReader.GetEnvironmentVariable("JWT_SECRET")
            };
        }

        private static LoggerSettings GetLoggerSettings()
        {
            return new LoggerSettings
            {
                ElasticSearchStringConnection = EnvironmentReader.GetEnvironmentVariable("LOGGER_STRING_CONNECTION")
            };
        }

        private static RabbitMQSettings GetRabbitMQSettings()
        {
            return new RabbitMQSettings
            {
                HostName = EnvironmentReader.GetEnvironmentVariable("RABBITMQ_HOST_NAME"),
                Port = int.Parse(EnvironmentReader.GetEnvironmentVariable("RABBITMQ_PORT")),
                VirtualHost = EnvironmentReader.GetEnvironmentVariable("RABBITMQ_VIRTUAL_HOST"),
                UserName = EnvironmentReader.GetEnvironmentVariable("RABBITMQ_USERNAME"),
                Password = EnvironmentReader.GetEnvironmentVariable("RABBITMQ_PASSWORD")
            };
        }
    }
}

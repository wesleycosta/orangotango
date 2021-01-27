using Orangotango.Core.Settings;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;
using Microsoft.Extensions.Configuration;

namespace Orangotango.DependencyInjection.Infrastructure
{
    public static class LoggerConfig
    {
        public static IConfiguration AddLogger(this IConfiguration configuration, AppSettings appSettings)
        {
            var uri = new Uri(appSettings.LoggerSettings.ElasticSearchStringConnection);
            var config = new ElasticsearchSinkOptions(uri)
            {
                AutoRegisterTemplate = true
            };

            Log.Logger = new LoggerConfiguration()
                             .Enrich.FromLogContext()
                             .WriteTo.Elasticsearch(config)
                             .CreateLogger();

            return configuration;
        }
    }
}

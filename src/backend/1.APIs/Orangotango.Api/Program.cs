using App.Metrics;
using App.Metrics.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace Orangotango.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureMetricsWithDefaults(builder =>
                {
                    builder.Report.ToInfluxDb(
                        opt =>
                        {
                            opt.InfluxDb.BaseUri = new Uri("http://127.0.0.1:8086");
                            opt.InfluxDb.Database = "metricsdb";
                            opt.InfluxDb.CreateDataBaseIfNotExists = true;
                        }
                    );
                })
                .UseMetrics()
                .UseMetricsWebTracking()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Api.Infrastructure.Swagger;
using Orangotango.Business.Hubs;
using Orangotango.DependencyInjection.Infrastructure;
using Orangotango.Api.Infrastructure.Authentication;
using Orangotango.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Orangotango.Api.Infrastructure.Cors;

namespace Orangotango.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            configuration.AddLogger(EnvironmentConfig.Builder());
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureInfrastructureAndDependencyInjection()
                    .AddJwtInfrastructure(EnvironmentConfig.Builder());

            services.AddControllers();
            services.AddSwaggerConfigApi();
            services.AddOrangotangoPolicy(EnvironmentConfig.Builder());
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            app.UseSwaggerConfigApi();
            app.UseHttpsRedirection();
            app.UseOrangotangoPolicy();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/notification-hub");
            });
        }
    }
}

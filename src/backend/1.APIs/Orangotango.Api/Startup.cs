using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orangotango.Api.Infrastructure.Swagger;
using Orangotango.Business.Hubs;
using Orangotango.DependencyInjection.Infrastructure;
using Orangotango.Api.Infrastructure.Authentication;
using Orangotango.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

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

            services.AddCors(options =>
            {
                options.AddPolicy("Allow",
                     policy => policy.WithOrigins("http://localhost:4200")
                                     .AllowAnyMethod()
                                     .AllowAnyHeader()
                                     .AllowCredentials());
            });

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            loggerFactory.AddSerilog();
            app.UseSwaggerConfigApi();
            app.UseHttpsRedirection();
            app.UseCors("Allow");
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

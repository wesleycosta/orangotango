using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orangotango.Core.Swagger;
using Orangotango.DependencyInjection;

namespace Orangotango.Authentication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureInfrastructureAndDependencyInjection();
            services.AddControllers();
            services.AddSwaggerConfigAuth();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UpdateDatabase();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwaggerConfigAuth();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}

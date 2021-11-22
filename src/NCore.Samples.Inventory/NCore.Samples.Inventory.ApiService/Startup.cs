using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using NCore.Practices.ApiVersioning.DependencyInjection;
using NCore.Practices.ApiVersioning.SwaggerExtensions;
using NCore.Samples.Inventory.Domain;
using NCore.Samples.Inventory.InMemoryEventStore;

namespace NCore.Samples.Inventory.ApiService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddNCoreDefaultVersionByNamespace(options =>
            {
            });
            services.AddNCoreDefaultVersionedSwaggerGen(options =>
            {
            });

            services.AddAutoMapper(GetType().Assembly);
            services.AddMediatR(GetType().Assembly);

            services.AddInventoryDomain();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseNCoreDefaultVersionedSwagger(provider);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NJsonSchema;
using NJsonSchema.Generation;
using Nooptime.Domain.Repositories;
using Nooptime.Domain.Services;
using Nooptime.Web.Controllers;
using NSwag.AspNetCore;
using Nooptime.Domain;

namespace Nooptime.Web
{
    public class Startup
    {
        private IWebHostEnvironment _hostingEnvironment;

        public Startup(IWebHostEnvironment env)
        {
            _hostingEnvironment = env;
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();
            services.AddControllers();
            
            var databaseConfig = new DatabaseConfiguration();
            Configuration.GetSection("Database").Bind(databaseConfig);
            services.AddSingleton<DatabaseConfiguration>(databaseConfig);

            services.AddScoped<IUptimeCheckRepository, UptimeCheckRepository>();
            services.AddScoped<IUptimeCheckService, UptimeCheckService>();
            services.AddSingleton<DocumentStoreFactory>();
            services.AddScoped<CanaryService>();

            services.AddOpenApiDocument(document =>
            {
                document.Description = "Hello world!";
                document.DefaultReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            
            if (_hostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            
            app.UseEndpoints(endPoints =>
            {
                endPoints.MapControllerRoute("status", "{controller=Home}/{action=Status}/{id?}");
                endPoints.MapControllers();
            });
            
            app.UseStaticFiles();
            
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseApiverse(settings =>
            {
                settings.ApiverseUrl = "https://localhost:5001";
            });
        }
    }
}
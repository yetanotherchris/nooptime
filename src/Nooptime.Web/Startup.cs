using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using Nooptime.Domain.Repositories;
using Nooptime.Domain.Services;
using Nooptime.Web.Controllers;
using NSwag.AspNetCore;
using Nooptime.Domain;

namespace Nooptime.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
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

            var databaseConfig = new DatabaseConfiguration();
            Configuration.GetSection("Database").Bind(databaseConfig);
            services.AddSingleton<DatabaseConfiguration>(databaseConfig);

            services.AddScoped<IUptimeCheckRepository, UptimeCheckRepository>();
            services.AddScoped<IUptimeCheckService, UptimeCheckService>();
            services.AddSingleton<DocumentStoreFactory>();
            services.AddScoped<CanaryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "status",
                    template: "{controller=Home}/{action=Status}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwaggerUi3(new Type[] { typeof(UptimeCheckController) }, settings =>
             {
                 new SwaggerUi3Settings()
                 {
                     DefaultPropertyNameHandling = PropertyNameHandling.CamelCase,
                     SwaggerUiRoute = "/swagger",
                     DefaultUrlTemplate = "{controller}/{action}/{id?}",
                     Title = "Nooptime API",
                     Description = "The RESTful API for Nooptime"
                 };
             });
        }
    }
}
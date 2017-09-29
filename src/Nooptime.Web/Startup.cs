using System;
using System.Reflection;
using Marten;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using Nooptime.Domain.Models;
using Nooptime.Domain.Repositories;
using Nooptime.Domain.Services;
using Nooptime.Web.Controllers;
using NSwag.AspNetCore;

namespace Nooptime.Web
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
			services.AddMvc();
			services.AddScoped<IUptimeCheckRepository, UptimeCheckRepository>();
			services.AddScoped<IUptimeCheckService, UptimeCheckService>();
			services.AddScoped<IDocumentStore>(provider => CreateDocumentStore());
		}

		private IDocumentStore CreateDocumentStore()
		{
			const string ConnectionString = "database=nooptime;server=localhost;port=7878;uid=nooptime;pwd=nooptime;";

			var documentStore = DocumentStore.For(options =>
				{
					options.CreateDatabasesForTenants(c =>
					{
						c.MaintenanceDatabase(ConnectionString);
						c.ForTenant()
							.CheckAgainstPgDatabase()
							.WithOwner("nooptime")
							.WithEncoding("UTF-8")
							.ConnectionLimit(-1)
							.OnDatabaseCreated(_ =>
							{
								Console.WriteLine("Database created");
							});
					});

					options.Connection(ConnectionString);
					options.Schema.For<UptimeCheckData>().Index(x => x.Id);
				});

			return documentStore;
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
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

			app.UseSwaggerUi3(new Type[] { typeof(UptimeCheckController) }, settings =>
			 {
				 new SwaggerUi3Settings()
				 {
					 DefaultPropertyNameHandling = PropertyNameHandling.CamelCase,
					 SwaggerUiRoute = "/swagger",
					 DefaultUrlTemplate = "{controller}/{action}/{id?}"
				 };
			 });
		}
	}
}
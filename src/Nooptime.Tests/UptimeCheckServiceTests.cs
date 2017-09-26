using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using Marten;
using Nooptime.Domain.Models;
using Nooptime.Domain.Repositories;
using Xunit;

namespace NoopTime.Tests
{
	public class DatabaseFixture : IDisposable
	{
		private DockerHelper _dockerHelper;

		public DatabaseFixture()
		{
			_dockerHelper = new DockerHelper();
			_dockerHelper.RemovePostgresContainer();
			_dockerHelper.StartPostgres();
			Thread.Sleep(10000);
		}

		public void Dispose()
		{
		}
	}

	public class UptimeCheckServiceTests : IClassFixture<DatabaseFixture>
	{
		private const string ConnectionString = "database=nooptime;server=localhost;port=7878;uid=nooptime;pwd=nooptime;";

		public UptimeCheckServiceTests(DatabaseFixture fixture)
		{
		}

		[Fact]
		public async void Test1()
		{
			var store = DocumentStore.For(options =>
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

			var id = Guid.NewGuid();
			var repository = new UptimeCheckRepository(store);
			repository.Save(new UptimeCheckData()
			{
				Id = id,
				Name = "My name"
			});

			var loadedItem = await repository.Load(id);
			Console.WriteLine(loadedItem.Name);
		}
	}
}
using System;
using System.Linq;
using Marten;
using Nooptime.Domain.Models;
using Nooptime.Domain.Repositories;
using Nooptime.Tests.Helpers;
using Xunit;

namespace Nooptime.Tests.Integration.Repositories
{
	public class UptimeCheckRepositoryTests : IClassFixture<PostgresDockerFixture>
	{
		public UptimeCheckRepositoryTests()
		{
			DocumentStore documentStore = MartenHelper.GetDocumentStore();
			var repository = new UptimeCheckRepository(documentStore);
			repository.ClearDatabase();
		}

		[Fact]
		public async void insert_should_persist_instance_and_load_should_have_filled_properties()
		{
			// given
			DocumentStore documentStore = MartenHelper.GetDocumentStore();

			var id = Guid.NewGuid();
			var repository = new UptimeCheckRepository(documentStore);
			var uptimeCheckData = new UptimeCheckData()
			{
				Id = id,
				Name = "My name",
				Description = "My description",
				Interval = TimeSpan.FromHours(1)
			};

			// when
			repository.Insert(uptimeCheckData);

			// then
			var loadedItem = await repository.Load(id);

			Assert.NotNull(loadedItem);
			Assert.Equal(id, loadedItem.Id);
			Assert.Equal(uptimeCheckData.Name, loadedItem.Name);
			Assert.Equal(uptimeCheckData.Description, loadedItem.Description);
			Assert.Equal(uptimeCheckData.Interval, loadedItem.Interval);
		}

		[Fact]
		public async void update_should_save_instance_and_load_should_have_updated_properties()
		{
			// given
			DocumentStore documentStore = MartenHelper.GetDocumentStore();

			var id = Guid.NewGuid();
			var repository = new UptimeCheckRepository(documentStore);
			var uptimeCheckData = new UptimeCheckData()
			{
				Id = id,
				Name = "My name",
				Description = "My description",
				Interval = TimeSpan.FromHours(1)
			};
			repository.Insert(uptimeCheckData);

			uptimeCheckData.Name = "New name";
			uptimeCheckData.Description = "new description";
			uptimeCheckData.Interval = TimeSpan.FromDays(30);
			uptimeCheckData.Properties.Add("prop1", "value");

			// when
			repository.Update(uptimeCheckData);

			// then
			var loadedItem = await repository.Load(id);

			Assert.NotNull(loadedItem);
			Assert.Equal(id, loadedItem.Id);
			Assert.Equal(uptimeCheckData.Name, loadedItem.Name);
			Assert.Equal(uptimeCheckData.Description, loadedItem.Description);
			Assert.Equal(uptimeCheckData.Interval, loadedItem.Interval);
			Assert.Equal(uptimeCheckData.Properties["prop1"], "value");
		}

		[Fact]
		public async void list_should_return_all_instances()
		{
			// given
			DocumentStore documentStore = MartenHelper.GetDocumentStore();

			var repository = new UptimeCheckRepository(documentStore);
			var uptimeCheckData1 = new UptimeCheckData() { Id = Guid.NewGuid() };
			var uptimeCheckData2 = new UptimeCheckData() { Id = Guid.NewGuid() };
			var uptimeCheckData3 = new UptimeCheckData() { Id = Guid.NewGuid() };

			repository.Insert(uptimeCheckData1);
			repository.Insert(uptimeCheckData2);
			repository.Insert(uptimeCheckData3);

			// when
			var list = await repository.List();

			// then
			Assert.Equal(3, list.Count());
		}

		[Fact]
		public async void delete_should_remove_instance()
		{
			// given
			DocumentStore documentStore = MartenHelper.GetDocumentStore();

			var id = Guid.NewGuid();
			var repository = new UptimeCheckRepository(documentStore);
			var uptimeCheckData = new UptimeCheckData()
			{
				Id = id,
			};
			repository.Insert(uptimeCheckData);

			var list = await repository.List();
			int itemCount = list.Count();
			Assert.NotEqual(0, itemCount);

			// when
			await repository.Delete(uptimeCheckData.Id);

			// then
			list = await repository.List();
			itemCount = list.Count();
			Assert.Equal(0, itemCount);
		}
	}
}
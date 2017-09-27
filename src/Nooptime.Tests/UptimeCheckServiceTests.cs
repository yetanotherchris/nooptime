using System;
using Marten;
using Nooptime.Domain.Models;
using Nooptime.Domain.Repositories;
using Xunit;

namespace NoopTime.Tests
{
	public class UptimeCheckServiceTests : IClassFixture<PostgresDockerFixture>
	{
		[Fact]
		public async void save_should_persist_instance()
		{
			// given
			DocumentStore documentStore = MartenHelper.CreateDocumentStore();

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
			repository.Save(uptimeCheckData);

			// then
			var loadedItem = await repository.Load(id);

			Assert.NotNull(loadedItem);
			Assert.Equal(id, loadedItem.Id);
			Assert.Equal(uptimeCheckData.Name, loadedItem.Name);
			Assert.Equal(uptimeCheckData.Description, loadedItem.Description);
			Assert.Equal(uptimeCheckData.Interval, loadedItem.Interval);
		}
	}
}
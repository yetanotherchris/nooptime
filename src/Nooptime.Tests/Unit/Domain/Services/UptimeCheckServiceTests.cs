using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Nooptime.Domain.Models;
using Nooptime.Domain.Repositories;
using Nooptime.Domain.Services;
using Xunit;

namespace Nooptime.Tests.Unit.Domain.Services
{
	public class UptimeCheckServiceTests
	{
		private readonly Mock<IUptimeCheckRepository> _repositoryMock;
		private readonly UptimeCheckService _checkService;

		public UptimeCheckServiceTests()
		{
			_repositoryMock = new Mock<IUptimeCheckRepository>();
			_checkService = new UptimeCheckService(_repositoryMock.Object);
		}

		[Fact]
		public void create_should_use_repository()
		{
			// given
			var data = new UptimeCheckData()
			{
				Name = "Nom",
				Description = "Nomnom",
				Interval = TimeSpan.FromHours(1),
				Properties = new Dictionary<string, string>() { { "key", "value" } }
			};

			// when
			Guid id = _checkService.Create(data);

			// then
			Assert.NotEqual(id, Guid.Empty);
			_repositoryMock.Verify(x => x.Insert(data));
		}

		[Fact]
		public void update_should_use_repository()
		{
			// given
			var data = new UptimeCheckData()
			{
				Id = Guid.NewGuid(),
				Name = "Nom",
				Description = "Nomnom",
				Interval = TimeSpan.FromHours(1),
				Properties = new Dictionary<string, string>() { { "key", "value" } }
			};

			// when
			_checkService.Update(data);

			// then
			_repositoryMock.Verify(x => x.Update(data));
		}

		[Fact]
		public void delete_should_use_repository()
		{
			// given
			Guid id = Guid.NewGuid();

			// when
			_checkService.Delete(id);

			// then
			_repositoryMock.Verify(x => x.Delete(id));
		}

		[Fact]
		public async void load_should_use_repository()
		{
			// given
			Guid id = Guid.NewGuid();

			var data = new UptimeCheckData()
			{
				Id = id,
				Name = "Nom",
				Description = "Nomnom",
				Interval = TimeSpan.FromHours(1),
				Properties = new Dictionary<string, string>() { { "key", "value" } }
			};

			_repositoryMock.Setup(x => x.Load(id))
							.Returns(Task.Run(() => data));

			// when
			UptimeCheckData actualData = await _checkService.Load(id);

			// then
			Assert.Equal(data, actualData);
		}

		[Fact]
		public async void loadall_should_use_repository()
		{
			// given
			var data = new UptimeCheckData()
			{
				Id = Guid.NewGuid(),
				Name = "Nom",
				Description = "Nomnom",
				Interval = TimeSpan.FromHours(1),
				Properties = new Dictionary<string, string>() { { "key", "value" } }
			};

			var list = new List<UptimeCheckData>() { data };

			_repositoryMock.Setup(x => x.List())
				.Returns(Task.Run(() => list.AsEnumerable()));

			// when
			var actualDataList = await _checkService.LoadAll();

			// then
			Assert.Equal(1, actualDataList.Count());
		}
	}
}
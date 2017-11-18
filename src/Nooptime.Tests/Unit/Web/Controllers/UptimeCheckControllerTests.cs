using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Nooptime.Domain.Models;
using Nooptime.Domain.Services;
using Nooptime.Web.Controllers;
using Nooptime.Web.Models;
using Xunit;

namespace Nooptime.Tests.Unit.Web.Controllers
{
	public class UptimeCheckControllerTests
	{
		private readonly Mock<IUptimeCheckService> _checkServiceMock;
		private UptimeCheckController _controller;

		public UptimeCheckControllerTests()
		{
			_checkServiceMock = new Mock<IUptimeCheckService>();
			_controller = new UptimeCheckController(_checkServiceMock.Object);
		}

		[Fact]
		public void post_should_call_service()
		{
			// given
			Guid expectedId = Guid.NewGuid();

			var data = new UptimeCheckData()
			{
				Id = Guid.Empty,
				Name = "Nom",
				Description = "Nomnom",
				Interval = TimeSpan.FromHours(1),
				Properties = new Dictionary<string, string>() { { "key", "value" } }
			};

			var model = new UptimeCheckDataModel()
			{
				Id = data.Id,
				Name = data.Name,
				Description = data.Description,
				Interval = data.Interval,
				//Properties = data.Properties
			};

			_checkServiceMock.Setup(x => x.Create(data)).Returns(expectedId);

			// when
			var actualId = _controller.Post(model);

			// then
			Assert.Equal(expectedId, actualId);
			_checkServiceMock.Verify(x => x.Create(data));
		}

		[Fact]
		public void patch_should_call_service()
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

			var model = new UptimeCheckDataModel()
			{
				Id = data.Id,
				Name = data.Name,
				Description = data.Description,
				Interval = data.Interval,
				//Properties = data.Properties
			};

			// when
			_controller.Patch(model);

			// then
			_checkServiceMock.Verify(x => x.Update(data));
		}

		[Fact]
		public void delete_should_call_service()
		{
			// given
			Guid id = Guid.NewGuid();
			_checkServiceMock.Setup(x => x.Delete(id));

			// when
			_controller.Delete(id);

			// then
			_checkServiceMock.Verify(x => x.Delete(id));
		}

		[Fact]
		public async void get_should_use_service()
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

			_checkServiceMock.Setup(x => x.Load(id))
							.Returns(Task.Run(() => data));

			// when
			UptimeCheckData actualData = await _controller.Get(id);

			// then
			Assert.Equal(data, actualData);
		}

		[Fact]
		public async void getall_should_call_service()
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
			var expectedList = new List<UptimeCheckData>() { data };

			_checkServiceMock.Setup(x => x.LoadAll())
				.Returns(Task.Run(() => expectedList.AsEnumerable()));

			// when
			var actualList = await _controller.GetAll();

			// then
			Assert.Equal(expectedList, actualList);
		}
	}
}
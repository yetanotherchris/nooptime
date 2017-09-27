using System;
using System.Threading;

namespace Nooptime.Tests.Helpers
{
	public class PostgresDockerFixture : IDisposable
	{
		private readonly DockerHelper _dockerHelper;

		public PostgresDockerFixture()
		{
			_dockerHelper = new DockerHelper();

			if (!_dockerHelper.HasContainer())
			{
				// Remove any stale nooptime instance
				_dockerHelper.RemovePostgresContainer();

				_dockerHelper.CreateContainer();
				_dockerHelper.StartContainer();

				Console.WriteLine("Waiting for postgres to start...");
				Thread.Sleep(15000);
			}
		}

		public void Dispose()
		{
			//_dockerHelper.StopPostgres();
		}
	}
}
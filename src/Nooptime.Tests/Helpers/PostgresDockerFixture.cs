using System;
using System.Threading;

namespace NoopTime.Tests
{
	public class PostgresDockerFixture : IDisposable
	{
		private readonly DockerHelper _dockerHelper;

		public PostgresDockerFixture()
		{
			_dockerHelper = new DockerHelper();
			_dockerHelper.RemovePostgresContainer();
			_dockerHelper.StartPostgres();

			// Wait for postgres to start
			Console.WriteLine("Waiting 15 seconds for postgres to start...");
			Thread.Sleep(15000);
		}

		public void Dispose()
		{
			_dockerHelper.StopPostgres();
		}
	}
}
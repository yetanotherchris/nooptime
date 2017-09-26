using System;
using System.Collections.Generic;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace NoopTime.Tests
{
	public class DockerHelper
	{
		private readonly DockerClient _dockerClient;

		public DockerHelper()
		{
			_dockerClient = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine"))
				.CreateClient();
		}

		public void StartPostgres()
		{
			var config = new Config();
			var parameters = new CreateContainerParameters(config);
			parameters.Name = "nooptime-postgres";

			parameters.Env = new List<string>();
			parameters.Env.Add("POSTGRES_USER=nooptime");
			parameters.Env.Add("POSTGRES_PASSWORD=nooptime");

			parameters.ExposedPorts = new Dictionary<string, EmptyStruct>();
			parameters.ExposedPorts.Add("5432/tcp", new EmptyStruct());
			parameters.Image = "postgres";
			parameters.HostConfig = new HostConfig()
			{
				PublishAllPorts = true,
				PortBindings = new Dictionary<string, IList<PortBinding>>()
			};
			parameters.HostConfig.PortBindings.Add("5432/tcp", new List<PortBinding>()
			{
				new PortBinding()
				{
					HostIP = "",
					HostPort = "7878/tcp"
				}
			});

			var createresult = _dockerClient.Containers.CreateContainerAsync(parameters).Result;
			_dockerClient.Containers.StartContainerAsync(createresult.ID, new ContainerStartParameters());
		}

		public void RemovePostgresContainer()
		{
			var listParameters = new ContainersListParameters();
			listParameters.All = true;
			listParameters.Filters = new Dictionary<string, IDictionary<string, bool>>();
			listParameters.Filters.Add("name", new Dictionary<string, bool>() { { "nooptime-postgres", true } });

			var list = _dockerClient.Containers.ListContainersAsync(listParameters).Result;

			if (list.Count > 0)
			{
				foreach (ContainerListResponse item in list)
				{
					_dockerClient.Containers.RemoveContainerAsync(item.ID, new ContainerRemoveParameters() { Force = true }).Wait();
				}
			}
		}
	}
}
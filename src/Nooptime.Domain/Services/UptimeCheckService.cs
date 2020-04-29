using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nooptime.Domain.Models;
using Nooptime.Domain.Repositories;

namespace Nooptime.Domain.Services
{
	public interface IUptimeCheckService
	{
		Guid Create(UptimeCheckData uptimeCheckData);

		Task<UptimeCheckData> Load(Guid id);

		Task<IEnumerable<UptimeCheckData>> LoadAll();

		void Update(UptimeCheckData uptimeCheckData);

		void Delete(Guid id);

		// TODO:
		// Runs checks (ids)
		// Save result
		// Load results for check
		// Load result summaries
	}
	
	public class UptimeCheckService : IUptimeCheckService
	{
		private readonly IUptimeCheckRepository _uptimeCheckRepository;

		public UptimeCheckService(IUptimeCheckRepository uptimeCheckRepository)
		{
			_uptimeCheckRepository = uptimeCheckRepository;
		}

		public Guid Create(UptimeCheckData uptimeCheckData)
		{
			if (uptimeCheckData.Id == Guid.Empty)
				uptimeCheckData.Id = Guid.NewGuid();

			_uptimeCheckRepository.Insert(uptimeCheckData);

			return uptimeCheckData.Id;
		}

		public async Task<UptimeCheckData> Load(Guid id)
		{
			return await _uptimeCheckRepository.Load(id);
		}

		public async Task<IEnumerable<UptimeCheckData>> LoadAll()
		{
			return await _uptimeCheckRepository.List();
		}

		public void Update(UptimeCheckData uptimeCheckData)
		{
			_uptimeCheckRepository.Update(uptimeCheckData);
		}

		public void Delete(Guid id)
		{
			_uptimeCheckRepository.Delete(id);
		}
	}
}
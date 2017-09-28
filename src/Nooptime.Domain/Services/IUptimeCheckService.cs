using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nooptime.Domain.Models;
using Nooptime.Domain.Repositories;

namespace Nooptime.Domain.Services
{
	public interface IUptimeCheckService
	{
		void Create(UptimeCheckData uptimeCheckData);

		Task<UptimeCheckData> Load(Guid id);

		void Update(UptimeCheckData uptimeCheckData);

		void Delete(Guid id);

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

		public void Create(UptimeCheckData uptimeCheckData)
		{
			_uptimeCheckRepository.Insert(uptimeCheckData);
		}

		public async Task<UptimeCheckData> Load(Guid id)
		{
			return await _uptimeCheckRepository.Load(id);
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
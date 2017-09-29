using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nooptime.Domain.Models;

namespace Nooptime.Domain.Services
{
	public interface IUptimeCheckService
	{
		Guid Create(UptimeCheckData uptimeCheckData);

		Task<UptimeCheckData> Load(Guid id);

		Task<IEnumerable<UptimeCheckData>> LoadAll();

		void Update(UptimeCheckData uptimeCheckData);

		void Delete(Guid id);

		// Runs checks (ids)
		// Save result
		// Load results for check
		// Load result summaries
	}
}
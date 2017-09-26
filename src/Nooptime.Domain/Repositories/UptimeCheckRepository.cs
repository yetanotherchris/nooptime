using System;
using Nooptime.Domain.Models;

namespace Nooptime.Domain.Repositories
{
	public class UptimeCheckRepository : IUptimeCheckRepository
	{
		public UptimeCheckData[] List()
		{
			return null;
		}

		public UptimeCheckData Load(Guid id)
		{
			return null;
		}

		public void Save(UptimeCheckData uptimeCheckData)
		{
		}

		public void Delete(Guid id)
		{
		}
	}
}
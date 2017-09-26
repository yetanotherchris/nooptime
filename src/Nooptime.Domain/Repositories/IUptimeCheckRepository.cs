using System;
using System.Collections.Generic;
using System.Text;
using Nooptime.Domain.Models;

namespace Nooptime.Domain.Repositories
{
	public interface IUptimeCheckRepository
	{
		UptimeCheckData[] List();

		UptimeCheckData Load(Guid id);

		void Save(UptimeCheckData uptimeCheckData);

		void Delete(Guid id);
	}
}
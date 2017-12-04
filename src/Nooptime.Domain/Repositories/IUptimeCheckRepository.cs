using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nooptime.Domain.Models;

namespace Nooptime.Domain.Repositories
{
	public interface IUptimeCheckRepository
	{
		Task<IEnumerable<UptimeCheckData>> List();

		Task<UptimeCheckData> Load(Guid id);

		void Insert(UptimeCheckData uptimeCheckData);

		void Update(UptimeCheckData uptimeCheckData);

		Task Delete(Guid id);

		string TestConnection();
	}
}
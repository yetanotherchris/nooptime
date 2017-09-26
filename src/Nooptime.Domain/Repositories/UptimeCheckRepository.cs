using System;
using System.Threading.Tasks;
using Marten;
using Nooptime.Domain.Models;

namespace Nooptime.Domain.Repositories
{
	public class UptimeCheckRepository : IUptimeCheckRepository
	{
		private readonly IDocumentStore _store;

		public UptimeCheckRepository(IDocumentStore store)
		{
			_store = store;
		}

		public Task<UptimeCheckData[]> List()
		{
			return null;
		}

		public async Task<UptimeCheckData> Load(Guid id)
		{
			using (IDocumentSession session = _store.LightweightSession())
			{
				return await session.Query<UptimeCheckData>().FirstOrDefaultAsync(x => x.Id == id);
			}
		}

		public void Save(UptimeCheckData uptimeCheckData)
		{
			using (IDocumentSession session = _store.LightweightSession())
			{
				session.Store(uptimeCheckData);
				session.SaveChanges();
			}
		}

		public void Delete(Guid id)
		{
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marten;
using Marten.Util;
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

		public async Task<IEnumerable<UptimeCheckData>> List()
		{
			using (IDocumentSession session = _store.LightweightSession())
			{
				return await session.Query<UptimeCheckData>().ToListAsync();
			}
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

		public async Task Delete(Guid id)
		{
			var item = await Load(id);
			if (item != null)
			{
				using (IDocumentSession session = _store.LightweightSession())
				{
					session.Delete(item);
					session.SaveChanges();
				}
			}
		}

		internal void ClearDatabase()
		{
			using (IDocumentSession session = _store.LightweightSession())
			{
				session.DeleteWhere<UptimeCheckData>(x => true);
				session.SaveChanges();
			}
		}
	}
}
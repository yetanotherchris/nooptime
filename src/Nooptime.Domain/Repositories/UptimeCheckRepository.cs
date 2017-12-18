using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marten;
using Nooptime.Domain.Models;

namespace Nooptime.Domain.Repositories
{
    public class UptimeCheckRepository : IUptimeCheckRepository
    {
        public IDocumentStore _documentStore;

        public IDocumentStore DocumentStore
        {
            get
            {
                if (_documentStore == null)
                {
                    _documentStore = _documentStoreFactory.Create();
                }

                return _documentStore;
            }
        }

        private readonly DatabaseConfiguration _databaseConfiguration;
        private readonly DocumentStoreFactory _documentStoreFactory;

        public UptimeCheckRepository(DocumentStoreFactory documentStoreFactory, DatabaseConfiguration databaseConfiguration)
        {
            _documentStoreFactory = documentStoreFactory;
            _databaseConfiguration = databaseConfiguration;
        }

        public async Task<IEnumerable<UptimeCheckData>> List()
        {
            using (IDocumentSession session = DocumentStore.LightweightSession())
            {
                return await session.Query<UptimeCheckData>().ToListAsync();
            }
        }

        public async Task<UptimeCheckData> Load(Guid id)
        {
            using (IDocumentSession session = DocumentStore.LightweightSession())
            {
                return await session.Query<UptimeCheckData>().FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public void Insert(UptimeCheckData uptimeCheckData)
        {
            using (IDocumentSession session = DocumentStore.LightweightSession())
            {
                session.Insert(uptimeCheckData);
                session.SaveChanges();
            }
        }

        public void Update(UptimeCheckData uptimeCheckData)
        {
            using (IDocumentSession session = DocumentStore.LightweightSession())
            {
                session.Update(uptimeCheckData);
                session.SaveChanges();
            }
        }

        public async Task Delete(Guid id)
        {
            var item = await Load(id);
            if (item != null)
            {
                using (IDocumentSession session = DocumentStore.LightweightSession())
                {
                    session.Delete(item);
                    session.SaveChanges();
                }
            }
        }

        internal void ClearDatabase()
        {
            using (IDocumentSession session = DocumentStore.LightweightSession())
            {
                session.DeleteWhere<UptimeCheckData>(x => true);
                session.SaveChanges();
            }
        }

        public string TestConnection()
        {
            string connectionString = _databaseConfiguration.ConnectionString;
            connectionString += ";Timeout=3";

            try
            {

                using (Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(connectionString))
                {
                    connection.Open();
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failure: {ex.Message}";
            }
        }
    }
}
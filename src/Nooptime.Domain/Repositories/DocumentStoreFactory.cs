using System;
using Marten;
using Nooptime.Domain.Models;

namespace Nooptime.Domain.Repositories
{
    public class DocumentStoreFactory
    {
        private readonly DatabaseConfiguration _databaseConfiguration;
        private IDocumentStore _documentStore;

        public DocumentStoreFactory(DatabaseConfiguration databaseConfiguration) => _databaseConfiguration = databaseConfiguration;

        public IDocumentStore Create()
        {
            if (_documentStore != null)
                return _documentStore;

            var documentStore = DocumentStore.For(options =>
            {
                options.CreateDatabasesForTenants(c =>
                {
                    c.MaintenanceDatabase(_databaseConfiguration.ConnectionString);
                    c.ForTenant()
                        .CheckAgainstPgDatabase()
                        .WithOwner("nooptime")
                        .WithEncoding("UTF-8")
                        .ConnectionLimit(-1)
                        .OnDatabaseCreated(_ =>
                        {
                            Console.WriteLine("Database created");
                        });
                });

                options.Connection(_databaseConfiguration.ConnectionString);
                options.Schema.For<UptimeCheckData>().Index(x => x.Id);
            });

            _documentStore = documentStore;
            return _documentStore;
        }
    }
}
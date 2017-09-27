using System;
using Marten;
using Nooptime.Domain.Models;

namespace Nooptime.Tests.Helpers
{
	public class MartenHelper
	{
		private static DocumentStore _documentStore;
		private const string ConnectionString = "database=nooptime;server=localhost;port=7878;uid=nooptime;pwd=nooptime;";

		public static DocumentStore GetDocumentStore()
		{
			if (_documentStore == null)
			{
				_documentStore = DocumentStore.For(options =>
				{
					options.CreateDatabasesForTenants(c =>
					{
						c.MaintenanceDatabase(ConnectionString);
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

					options.Connection(ConnectionString);
					options.Schema.For<UptimeCheckData>().Index(x => x.Id);
				});
			}

			return _documentStore;
		}
	}
}
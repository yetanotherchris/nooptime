using System.Collections.Generic;
using Nooptime.Domain.Repositories;

namespace Nooptime.Domain.Services
{
    public class CanaryService
    {
        private readonly IUptimeCheckRepository _uptimeCheckRepository;

        public CanaryService(IUptimeCheckRepository uptimeCheckRepository)
        {
            _uptimeCheckRepository = uptimeCheckRepository;
        }

        public Dictionary<string, string> RunTests()
        {
            var dictionary = new Dictionary<string, string>();

            // Check Postgres
            string postgresTest = _uptimeCheckRepository.TestConnection();
            dictionary.Add("Postgres", postgresTest);

            return dictionary;
        }
    }
}
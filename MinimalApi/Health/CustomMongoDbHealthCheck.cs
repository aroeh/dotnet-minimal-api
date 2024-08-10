using Microsoft.Extensions.Diagnostics.HealthChecks;
using MinimalApi.DataAccess;

namespace MinimalApi.Health
{
    public class CustomMongoDbHealthCheck(IMongoService mongo) : IHealthCheck
    {
        private readonly IMongoService mongoService = mongo;

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken token = new())
        {
            try
            {
                var dbNames = await mongoService.Client.ListDatabaseNamesAsync(token);
                return await Task.FromResult(HealthCheckResult.Healthy("Database connection is healthy"));
            }
            catch (Exception ex)
            {

                return HealthCheckResult.Unhealthy("Unable to connect to the database", ex);
            }
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using My.DDD.CQRS.Temp6.AzureTables.Repositories;
using My.DDD.CQRS.Temp6.AzureTables.Services;
using My.DDD.CQRS.Temp6.Domain.ExempleAggregate;

namespace My.DDD.CQRS.Temp6.AzureTables
{
    public static class DependencyInjection
    {

        public static IServiceCollection TryAddAzureTables(this IServiceCollection services, string connectionString)
        {
            services.TryAddSingleton<IExempleRepository>(s => new ExempleRepository("ExempleTable", connectionString));
            return services;
        }
        public static IServiceCollection TryAddAzureTablesRepositories(this IServiceCollection services)
        {
            services.TryAddScoped<IExempleService, ExempleService>();
            return services;
        }
    }
}

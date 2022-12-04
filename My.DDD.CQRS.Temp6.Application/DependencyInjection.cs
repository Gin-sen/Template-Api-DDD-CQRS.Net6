using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace My.DDD.CQRS.Temp6.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);

            return services;
        }

    }
}

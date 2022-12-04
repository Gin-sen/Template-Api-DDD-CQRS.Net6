using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace My.DDD.CQRS.Temp6.Contracts
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddContractsLayer(this IServiceCollection services)
    {

      services.AddMediatR(typeof(DependencyInjection).Assembly);

      return services;
    }
  }
}

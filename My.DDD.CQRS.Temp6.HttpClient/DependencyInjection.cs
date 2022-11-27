using Microsoft.Extensions.DependencyInjection;
using My.DDD.CQRS.Temp6.Domain.TodoAggregate;
using My.DDD.CQRS.Temp6.HttpClients.Clients;

namespace My.DDD.CQRS.Temp6.HttpClient
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddHttpServices(this IServiceCollection services)
    {

      services.AddHttpClient<IPlaceholderClient, PlaceholderClient>(client =>
      {
        client.BaseAddress = new("https://jsonplaceholder.typicode.com");
      });

      return services;
    } 
  }
}
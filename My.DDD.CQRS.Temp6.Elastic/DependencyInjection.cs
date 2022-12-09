using Elastic.Clients.Elasticsearch.IndexManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using My.DDD.CQRS.Temp6.Elastic.Clients;

namespace My.DDD.CQRS.Temp6.Elastic
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddLogstashClient(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddHttpClient<ILogstashClientService, LogstashClientService>(client =>
      {
        client.BaseAddress = new(configuration["Logging:Logstash:Url"]);
      });
      return services;
    }
  }
}
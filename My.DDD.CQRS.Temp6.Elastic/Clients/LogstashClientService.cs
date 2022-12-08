

namespace My.DDD.CQRS.Temp6.Elastic.Clients
{
  public class LogstashClientService : ILogstashClientService
  {

    private readonly HttpClient _httpClient;

    public LogstashClientService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public Task SendLog(string indexName, string message)
    {
      throw new NotImplementedException();
    }
  }
}

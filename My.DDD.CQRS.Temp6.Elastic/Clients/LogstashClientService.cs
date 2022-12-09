

using Microsoft.Extensions.Logging;
using My.DDD.CQRS.Temp6.Elastic.Models;
using System.Net.Http.Json;

namespace My.DDD.CQRS.Temp6.Elastic.Clients
{
  public class LogstashClientService : ILogstashClientService
  {

    private readonly HttpClient _httpClient;
    private readonly ILogger<LogstashClientService> _logger;

    public LogstashClientService(HttpClient httpClient, ILogger<LogstashClientService> logger)
    {
      _httpClient = httpClient;
      _logger = logger;
    }

    public async Task SendLog(string indexName, object message)
    {
      try
      {
        LogstashDto dto = new() { IndexName = indexName, Message = message };
        _logger.LogInformation("Sending doc for index {indexName} to Logstash", indexName);
        using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(requestUri: "", value: dto);
        response.EnsureSuccessStatusCode();
        string returnValue = await response.Content.ReadAsStringAsync();
      }
      catch (HttpRequestException ex)
      {
        _logger.LogError("Http error while sending doc for index {indexName} to Logstash: {ex}", indexName, ex);
        throw;
      }
      catch (Exception exeption)
      {
        _logger.LogCritical("Uncatched Exception : {exeption}", exeption);
        throw;
      }
    }
  }
}

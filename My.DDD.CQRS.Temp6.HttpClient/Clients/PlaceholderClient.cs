using My.DDD.CQRS.Temp6.Domain.TodoAggregate;
using System;
using System.Net.Http.Json;
using Http = System.Net.Http;

namespace My.DDD.CQRS.Temp6.HttpClients.Clients
{
  public class PlaceholderClient : IPlaceholderClient
  {
    private const string ApiKey = "hello";

    private readonly Http.HttpClient _httpClient;

    public PlaceholderClient(IHttpClientFactory httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<Todo?> GetTodo(int id)
    {
      return await _httpClient.GetFromJsonAsync<Todo>($"todos/{id}");
    }
  }
}

using My.DDD.CQRS.Temp6.Domain.TodoAggregate;
using System;
using System.Net.Http.Json;
using System.Text.Json;
using Http = System.Net.Http;

namespace My.DDD.CQRS.Temp6.HttpClients.Clients
{
  public class PlaceholderClient : IPlaceholderClient
  {
    private const string ApiKey = "hello";

    private readonly Http.HttpClient _httpClient;

    public PlaceholderClient(Http.HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<Todo?> GetTodo(int id)
    {
      using HttpResponseMessage response = await _httpClient.GetAsync($"todos/{id}");
      response.EnsureSuccessStatusCode();
      var jsonResponse = await response.Content.ReadAsStringAsync();
      Todo? result = JsonSerializer.Deserialize<Todo>(jsonResponse);
      if (result == null)
        return null;
      return result;
    }
  }
}

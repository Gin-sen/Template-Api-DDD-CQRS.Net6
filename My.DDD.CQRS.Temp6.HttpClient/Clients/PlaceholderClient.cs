using My.DDD.CQRS.Temp6.HttpClient.Models;
using System;
using System.Net.Http.Json;
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
      return await _httpClient.GetFromJsonAsync<Todo>($"todos/{id}");
    }
  }
}

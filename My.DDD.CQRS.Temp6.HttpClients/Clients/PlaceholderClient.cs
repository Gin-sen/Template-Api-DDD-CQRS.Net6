using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
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
      try
      {
        using HttpResponseMessage response = await _httpClient.GetAsync($"todos/{id}");
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        Todo? result = JsonSerializer.Deserialize<Todo>(jsonResponse);
        if (result == null)
          return null;
        return result;
      }
      catch (HttpRequestException)
      {
        return null;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<User?> GetUser(int id)
    {
      try
      {
        using HttpResponseMessage response = await _httpClient.GetAsync($"users/{id}");
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        User? result = JsonSerializer.Deserialize<User>(jsonResponse);
        if (result == null)
          return null;
        return result;
      }
      catch (HttpRequestException)
      {
        return null;
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}

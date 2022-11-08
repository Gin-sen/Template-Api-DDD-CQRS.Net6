using My.DDD.CQRS.Temp6.Headers;
using My.DDD.CQRS.Temp6.Messaging.Contexting;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace My.DDD.CQRS.Temp6.Messaging.Headers;

public class HeaderContextAccessor : IHeaderContextAccessor
{
  private readonly IMessageContextAccessor messageContextAccessor;

  public HeaderContextAccessor(IMessageContextAccessor messageContextAccessor)
  {
    this.messageContextAccessor = messageContextAccessor;
  }

  public IEnumerable<KeyValuePair<string, StringValues>> ListAll()
  {
    IEnumerable<KeyValuePair<string, StringValues>> result = new List<KeyValuePair<string, StringValues>>();
    var headers = messageContextAccessor.Current?.Message?.Headers;

    if (headers != null)
      result = headers;

    return result;
  }

  public bool TryGetValue(string key, out StringValues value)
  {
    value = default;

    var result = messageContextAccessor.Current?.Message?.Headers.TryGetValue(key, out value);

    return result == true;
  }

  public bool TryGetValue<T>(string key, [MaybeNull] out T value)
  {
    StringValues stringValue = default;

    var result = messageContextAccessor.Current?.Message?.Headers.TryGetValue(key, out stringValue) == true;
    value = JsonConvert.DeserializeObject<T>(stringValue);

    return result;
  }
}
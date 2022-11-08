using Microsoft.Extensions.Primitives;

namespace My.DDD.CQRS.Temp6.Messaging.Headers;

public class MessageHeaders : Dictionary<string, StringValues>
{
    public MessageHeaders()
    {
    }

    public MessageHeaders(IEnumerable<KeyValuePair<string, StringValues>> values)
    {
        values
          .ToList()
          .ForEach(value => Add(value.Key, value.Value));
    }
}
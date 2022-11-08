using My.DDD.CQRS.Temp6.Messaging.Headers;

using Microsoft.Extensions.Primitives;

namespace My.DDD.CQRS.Temp6.Messaging;

public class Message
{
    public Message()
    {
        Headers = new MessageHeaders();
    }

    public Message(string? body)
      : this()
    {
        Body = body;
    }

    public Message(string? body, IEnumerable<KeyValuePair<string, StringValues>> headers)
    {
        Body = body;
        Headers = new MessageHeaders(headers);
    }

    public Message(string? body, IEnumerable<KeyValuePair<string, string[]>> headers)
    {
        Body = body;
        Headers = new MessageHeaders(headers.Select(header => new KeyValuePair<string, StringValues>(header.Key, new StringValues(header.Value))));
    }

    public virtual string? Body { get; set; }

    public virtual MessageHeaders Headers { get; set; }
}
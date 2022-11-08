using My.DDD.CQRS.Temp6.Headers;

namespace My.DDD.CQRS.Temp6.Messaging.Headers;

public class HeaderPropagationMessageBuilder : IMessageBuilder
{
    private readonly IHeaderContextAccessor headerContextAccessor;
    private readonly IHeaderPropagationRegistrer? headerPropagationRegistrer;
    private readonly HeaderPropagationOptions? headerPropagationOptions;

    public HeaderPropagationMessageBuilder(IHeaderContextAccessor headerContextAccessor, IHeaderPropagationRegistrer? headerPropagationRegistrer = null, HeaderPropagationOptions? headerPropagationOptions = null)
    {
        this.headerContextAccessor = headerContextAccessor;
        this.headerPropagationRegistrer = headerPropagationRegistrer;
        this.headerPropagationOptions = headerPropagationOptions;
    }

    public bool CanBuild(Message message)
    {
        var result = headerPropagationOptions?.Headers.Any() == true || headerPropagationRegistrer?.Headers.Any() == true;

        return result;
    }

    public void Build(Message message)
    {
        headerPropagationOptions?.Headers
          .ToList()
          .ForEach(header =>
          {
              if (headerContextAccessor.TryGetValue(header, out var value))
                  message.Headers.Add(header, value);
          });

        headerPropagationRegistrer?.Headers
          .ToList()
          .ForEach(header =>
          {
              if (headerContextAccessor.TryGetValue(header.HeaderName, out var value))
                  message.Headers.Add(header.HeaderName, value);
          });
    }
}
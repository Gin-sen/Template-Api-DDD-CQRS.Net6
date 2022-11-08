using My.DDD.CQRS.Temp6.Hosting;

namespace My.DDD.CQRS.Temp6.Messaging;

public class MessagingHostingInitializer : IHostingInitializer
{
  private readonly IMessagingInitializer? messagingInitializer;

  public MessagingHostingInitializer(IMessagingInitializer? messagingInitializer = null)
  {
    this.messagingInitializer = messagingInitializer;
  }

  public int Order => 2;

  public void Initialize()
  {
    messagingInitializer?.Initialize();
  }
}
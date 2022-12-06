using Azure.Messaging.EventHubs.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.EventHub.Provider
{
  /// <summary>
  /// EventHubClientProvider ( Dependency injected Singleton )
  /// </summary>
  public class EventHubClientProvider
  {
    /// <summary>
    /// The event hub client
    /// </summary>
    private readonly EventHubProducerClient _eventHubClient;

    /// <summary>
    /// EventHubClientProvider ctr
    /// </summary>
    public EventHubClientProvider()
    {
      _eventHubClient = new EventHubProducerClient("Endpoint=sb://eventhubelk.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=NtkfwpRbxKb8eavl+2bGaltytzhHdufE5J9/6fZtNBE=", "EventHubElk1");
    }

    /// <summary>
    /// GetClient
    /// </summary>
    /// <returns></returns>
    public EventHubProducerClient GetClientInstance()
    {
      return _eventHubClient;
    }
  }
}

using MY.DDD.CQRS.Temp6.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.EventBus.Events
{
  public class IntegrationEvent
  {
    public IntegrationEvent()
    {
      Id = Guid.NewGuid();
      CreationDate = DateTime.UtcNow;
    }

    [JsonConstructor]
    public IntegrationEvent(Guid id, DateTime createDate)
    {
      Id = id;
      CreationDate = createDate;
    }

    [JsonPropertyName("id")]
    public Guid Id { get; private set; }

    [JsonPropertyName("creation_date")]
    public DateTime CreationDate { get; private set; }
  }
}

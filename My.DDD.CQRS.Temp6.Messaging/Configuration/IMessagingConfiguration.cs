using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Messaging.Configuration
{
  public interface IMessagingConfiguration
  {
    public string? HostName { get; set; }
    public int? Port { get; set; }
  }
}

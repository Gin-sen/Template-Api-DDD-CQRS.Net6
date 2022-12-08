using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Elastic.Clients
{
  public interface ILogstashClientService
  {
    Task SendLog(string indexName, string message);
  }
}

using Elastic.Clients.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Elastic.Factory
{
  public class ElasticsearchClientFactory
  {
    public static ElasticsearchClient Create(string host, int port)
    {
      return new ElasticsearchClient();
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Elastic.Models
{
    public class LogstashDto
  {
    public string IndexName { get; set; }
    public object Message { get; set; }
  }
}

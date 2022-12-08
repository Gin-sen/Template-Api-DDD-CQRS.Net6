using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Logging.Configurations
{
    public sealed class LogstashLoggerConfiguration
  {
    public int EventId { get; set; }
    public string? IndexName { get; set; }
    
    public LogLevel Default { get; set; } 
  }
}

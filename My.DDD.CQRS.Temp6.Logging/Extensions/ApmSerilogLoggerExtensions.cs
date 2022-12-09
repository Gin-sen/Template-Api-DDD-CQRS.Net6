using Elastic.Apm.SerilogEnricher;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Logging.Extensions
{
    public static class ApmSerilogLoggerExtensions
    {
    public static ILoggingBuilder AddApmSerilogLogger(this ILoggingBuilder builder)
    {
      var logger = new LoggerConfiguration()
         .Enrich.WithElasticApmCorrelationInfo()
         .WriteTo.Console(outputTemplate: "[{ElasticApmTraceId} {ElasticApmTransactionId} {Message:lj} {NewLine}{Exception}")
         .CreateLogger();

      builder.AddSerilog(logger);
      return builder;
    }
  }
}

using Elastic.Apm.SerilogEnricher;
using Serilog;

namespace My.DDD.CQRS.Temp6.Logging.Tracing
{
    public static class TraceHelper
    {
        public static void LogConsole()
        {
            Log.Logger = new LoggerConfiguration()
              .Enrich.WithElasticApmCorrelationInfo()
              .WriteTo.Console(outputTemplate: "[{ElasticApmTraceId} {ElasticApmTransactionId} {Level:u3}] {Message:lj} {NewLine}{Exception}")
              .CreateLogger();
        }
    }
}
using Microsoft.Extensions.Hosting;
using My.DDD.CQRS.Temp6.Logging.Tracing;
//#if !DEBUG
using Elastic.Apm.NetCoreAll;
//#endif
using Serilog;
using Elastic.Apm.SerilogEnricher;

namespace My.DDD.CQRS.Temp6.Logging.Extensions
{
  public static class HostBuilderExtensions
  {
    public static IHostBuilder UseLog(this IHostBuilder hostBuilder)
    {
      //#if !DEBUG
      hostBuilder.UseAllElasticApm();
      //#endif
      var logger = new LoggerConfiguration()
         .Enrich.WithElasticApmCorrelationInfo()
         .WriteTo.Console(outputTemplate: "[{ElasticApmTraceId} {ElasticApmTransactionId} {Message:lj} {NewLine}{Exception}")
         .CreateLogger();

      hostBuilder.ConfigureLogging(builder => builder.AddSerilog(logger));

      return hostBuilder;
    }
  }

}

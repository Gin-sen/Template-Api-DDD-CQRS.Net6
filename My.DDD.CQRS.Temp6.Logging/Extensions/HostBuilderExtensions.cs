using Microsoft.Extensions.Hosting;
using My.DDD.CQRS.Temp6.Logging.Tracing;
#if !DEBUG
using Elastic.Apm.NetCoreAll;
#endif
using Serilog;

namespace My.DDD.CQRS.Temp6.Logging.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder UseLog(this IHostBuilder hostBuilder)
        {
            TraceHelper.LogConsole();

            hostBuilder.UseSerilog();

#if !DEBUG
    hostBuilder.UseAllElasticApm();
#endif

            return hostBuilder;
        }
    }

}

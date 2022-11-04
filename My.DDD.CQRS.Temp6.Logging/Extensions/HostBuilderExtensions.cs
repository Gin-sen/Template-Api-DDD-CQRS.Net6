using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using My.DDD.CQRS.Temp6.Logging.Tracing;
#if !DEBUG
using Elastic.Apm.NetCoreAll;
#endif
using Serilog;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using My.DDD.CQRS.Temp6.Logging.Configurations;
using My.DDD.CQRS.Temp6.Logging.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Logging.Extensions
{
  public static class LogstashLoggerExtensions
  {
    public static ILoggingBuilder AddLogstashLogger(this ILoggingBuilder builder)
    {
      builder.AddConfiguration();
      
      builder.Services.TryAddEnumerable(
        ServiceDescriptor.Singleton<ILoggerProvider, LogstashLoggerProvider>());

      LoggerProviderOptions.RegisterProviderOptions
        <LogstashLoggerConfiguration, LogstashLoggerProvider>(builder.Services);

      return builder;
    }
    public static ILoggingBuilder AddLogstashLogger(
      this ILoggingBuilder builder,
      Action<LogstashLoggerConfiguration> configure)
    {
      builder.AddLogstashLogger(configure);
      builder.Services.Configure(configure);
      return builder;
    }
  }
}

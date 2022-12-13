using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using My.DDD.CQRS.Temp6.Logging.Configurations;
using My.DDD.CQRS.Temp6.Logging.Loggers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Logging.Providers
{
  [UnsupportedOSPlatform("browser")]
  [ProviderAlias("Logstash")]
  public sealed class LogstashLoggerProvider : ILoggerProvider
  {
    private readonly IDisposable? _onChangeToken;
    private LogstashLoggerConfiguration _currentConfig;
    private readonly ConcurrentDictionary<string, LogstashLogger> _loggers =
      new(StringComparer.OrdinalIgnoreCase);
    private readonly IConfiguration _apiconfiguration;

    public LogstashLoggerProvider(IOptionsMonitor<LogstashLoggerConfiguration> config, IConfiguration apiconfiguration)
    {
      _currentConfig = config.CurrentValue;
      _onChangeToken = config.OnChange(updatedConfig => _currentConfig = updatedConfig);
      _apiconfiguration = apiconfiguration;
    }


    public ILogger CreateLogger(string categoryName) =>
       _loggers.GetOrAdd(categoryName, name => new LogstashLogger(name, GetCurrentConfig));

    private LogstashLoggerConfiguration GetCurrentConfig() => _currentConfig;
    public void Dispose()
    {
      _loggers.Clear();
      _onChangeToken?.Dispose();
    }
  }
}

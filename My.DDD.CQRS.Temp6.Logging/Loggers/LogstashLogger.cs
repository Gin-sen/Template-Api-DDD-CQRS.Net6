using Microsoft.Extensions.Logging;
using My.DDD.CQRS.Temp6.Elastic.Clients;
using My.DDD.CQRS.Temp6.Logging.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Logging.Loggers
{
  public sealed class LogstashLogger : ILogger
  {
    private readonly string _name;
    private readonly Func<LogstashLoggerConfiguration> _getCurrentConfig;
    //private readonly ILogstashClientService _client;

    //public LogstashLogger(string name, Func<LogstashLoggerConfiguration> getCurrentConfig, ILogstashClientService client)
    public LogstashLogger(string name, Func<LogstashLoggerConfiguration> getCurrentConfig)
    {
      //(_name, _getCurrentConfig, _client) = (name, getCurrentConfig, client);
      (_name, _getCurrentConfig) = (name, getCurrentConfig);
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => default!;

    public bool IsEnabled(LogLevel logLevel)
    {
      return _getCurrentConfig().Default.CompareTo(logLevel) <= 0 ? true : false;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
      if (!IsEnabled(logLevel))
      {
        return;
      }

      LogstashLoggerConfiguration config = _getCurrentConfig();
      if (config.EventId == 0 || config.EventId == eventId.Id)
      {
        Console.Write($"[{eventId.Id,2}: {logLevel,-12}]");

        Console.Write($"     {_name} - ");

        Console.Write($"{formatter(state, exception)}");

        Console.WriteLine();
      }
    }
  }
}

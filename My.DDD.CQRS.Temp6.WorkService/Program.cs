using Microsoft.Extensions.Logging.Configuration;
using My.DDD.CQRS.Temp6.Logging.Extensions;
using My.DDD.CQRS.Temp6.WorkService.Services;

namespace My.DDD.CQRS.Temp6.WorkService
{
  public class Program
  {
    public static async Task Main(string[] args)
    //public static void Main(string[] args)
    {
      using IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureLogging(builder =>
        {
          // Init Logging conf
          builder.ClearProviders();
          builder.AddConfiguration();

          // Add multiple loggers
          builder.AddLogstashLogger();
          builder.AddApmSerilogLogger();
        })
        .ConfigureServices(services =>
        {
          // Timer implementation
          services.AddHostedService<TimerService>();

          // Then Default BackgroundService
          //services.AddHostedService<Worker>();
        })
        .Build();


      var logger = host.Services.GetRequiredService<ILogger<Program>>();

      logger.LogDebug(1, "Does this line get hit?");    // Not logged
      logger.LogInformation(3, "Nothing to see here."); // Logs in ConsoleColor.DarkGreen
      logger.LogWarning(5, "Warning... that was odd."); // Logs in ConsoleColor.DarkCyan
      logger.LogError(7, "Oops, there was an error.");  // Logs in ConsoleColor.DarkRed
      logger.LogTrace(5!, "== 120.");                   // Not logged


      await host.RunAsync();
      //host.Run();
    }
  }
}
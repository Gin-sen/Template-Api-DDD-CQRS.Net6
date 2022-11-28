using Microsoft.Extensions.Hosting;
using System.Timers;

namespace My.DDD.CQRS.Temp6.WorkService
{
  public class Worker : BackgroundService
  {
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly ILogger<Worker> _logger;

    public Worker(
        IHostApplicationLifetime hostApplicationLifetime, ILogger<Worker> logger) =>
        (_hostApplicationLifetime, _logger) = (hostApplicationLifetime, logger);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      // https://learn.microsoft.com/fr-fr/dotnet/core/extensions/queue-service
      while (!stoppingToken.IsCancellationRequested)
      {
        _logger.LogInformation("Worker main thread running at: {time}", DateTimeOffset.Now);
        await Task.Delay(1000, stoppingToken);
      }
      // TODO: implement single execution logic here if needed.
      _logger.LogInformation(
          "Work done at: {time}", DateTimeOffset.Now);

      // When completed, the entire app host will stop.
      _hostApplicationLifetime.StopApplication();
    }

    private void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
      _logger.LogInformation(
          "Worker timer event at: {time}", DateTimeOffset.Now); ;
    }
  }
}
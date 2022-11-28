using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.WorkService.Services
{

  public sealed class TimerService : IHostedService, IAsyncDisposable
  {
    private readonly Task _completedTask = Task.CompletedTask;
    private readonly ILogger<TimerService> _logger;
    private int _executionCount = 0;
    private Timer? _timer;

    public TimerService(ILogger<TimerService> logger) => _logger = logger;

    public Task StartAsync(CancellationToken stoppingToken)
    {
      _logger.LogInformation("{Service} is running.", nameof(WorkService));
      _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

      return _completedTask;
    }

    private void DoWork(object? state)
    {
      int count = Interlocked.Increment(ref _executionCount);

      _logger.LogInformation(
          "{Service} is working, execution count: {Count:#,0}",
          nameof(WorkService),
          count);
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
      _logger.LogInformation(
          "{Service} is stopping.", nameof(WorkService));

      _timer?.Change(Timeout.Infinite, 0);

      return _completedTask;
    }

    public async ValueTask DisposeAsync()
    {
      if (_timer is IAsyncDisposable timer)
      {
        await timer.DisposeAsync();
      }

      _timer = null;
    }
  }
}

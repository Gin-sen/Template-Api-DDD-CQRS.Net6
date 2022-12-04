namespace My.DDD.CQRS.Temp6.WorkService.Services
{

    public sealed class TimerService : IHostedService, IAsyncDisposable
    {
        private readonly Task _completedTask = Task.CompletedTask;
        private readonly ILogger<TimerService> _logger;
        private int _executionCount = 0;
        private int _maxCount = 20;
        private Timer? _timer;

        public TimerService(ILogger<TimerService> logger) => _logger = logger;

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("{Service} is running.", nameof(WorkService));
            var autoEvent = new AutoResetEvent(false);
            _timer = new Timer(DoWork, autoEvent, 1000, 250);

            //autoEvent.WaitOne();
            //_timer.Change(0, 500);
            //_logger.LogInformation("\nChanging period to .5 seconds.\n");

            // When autoEvent signals the second time, dispose of the timer.
            autoEvent.WaitOne();
            _timer.Dispose();
            _logger.LogInformation("\nDestroying timer.");

            return _completedTask;
        }

        private void DoWork(object? state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));
            AutoResetEvent autoEvent = (AutoResetEvent)state;
            int count = Interlocked.Increment(ref _executionCount);

            _logger.LogInformation(
                "{Service} is working, execution count: {Count:#,0}",
                nameof(WorkService),
                count);

            if (count == _maxCount)
            {
                // Reset the counter and signal the waiting thread.
                _executionCount = 0;
                autoEvent.Set();
            }
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

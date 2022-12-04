using My.DDD.CQRS.Temp6.WorkService.Services;

namespace My.DDD.CQRS.Temp6.WorkService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
              .ConfigureServices(services =>
              {
                  // Timer implementation
                  services.AddHostedService<TimerService>();

                  // Then Default BackgroundService
                  //services.AddHostedService<Worker>();
              })
              .Build();

            host.Run();
        }
    }
}
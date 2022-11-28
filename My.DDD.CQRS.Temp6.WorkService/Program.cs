using My.DDD.CQRS.Temp6.WorkService.Services;

namespace My.DDD.CQRS.Temp6.WorkService
{
  public class Program
  {
    public static void Main(string[] args)
    {
      // Default Worker implementation
      //IHost host = Host.CreateDefaultBuilder(args)
      //    .ConfigureServices(services =>
      //    {
      //      services.AddHostedService<Worker>();
      //    })
      //    .Build();

      // Timer implementation
      using IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices(services =>
        {
          services.AddHostedService<TimerService>();
          
        })
        .Build();

      host.Run();
    }
  }
}
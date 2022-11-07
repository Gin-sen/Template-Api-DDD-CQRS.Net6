using Microsoft.AspNetCore.Mvc.ApiExplorer;
using My.DDD.CQRS.Temp6.Http.Bootstrap.Extensions;
using My.DDD.CQRS.Temp6.Logging.Extensions;
using Serilog;

namespace My.DDD.CQRS.Temp6.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      // Build
      var builder = CreateWebHostBuilder(args);
      var startup = new Startup(builder.Configuration);
      // Add services
      startup.ConfigureServices(builder.Services);
      var app = builder.Build();
      // Configure application
      startup.Configure(app, app.Environment);
      // Run WebApplication
      app.Run();
    }

    public static WebApplicationBuilder CreateWebHostBuilder(string[] args)
    {
      var build = WebApplication.CreateBuilder(args);
      build.Host.UseLog();
      return build;
    }
  }
}
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using My.DDD.CQRS.Temp6.Http.Bootstrap.Extensions;

namespace My.DDD.CQRS.Temp6.Api;

public class Startup
{
  private readonly IConfiguration configuration;

  public Startup(IConfiguration configuration)
  {
    this.configuration = configuration;
  }

  public void ConfigureServices(IServiceCollection services)
  {
    services
      .AddHttpArchitecture(configuration);
      //.AddMessagingInHttpContext(configuration)
      //.AddDatabase<ApplicationDbContext>(hostEnvironment, configuration);
  }

  public void Configure(WebApplication app, IWebHostEnvironment environment)
  {
    app.UseHttpArchitecture();
  }
}
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection.Extensions;
using My.DDD.CQRS.Temp6.CQRS.Events;
using My.DDD.CQRS.Temp6.Http.Bootstrap.Extensions;
using System.ComponentModel.Design;

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
    services.TryAddScoped<Exemple, >
      //.AddMessagingInHttpContext(configuration)
      //.AddDatabase<ApplicationDbContext>(hostEnvironment, configuration);
  }

  public void Configure(WebApplication app, IWebHostEnvironment environment)
  {
    app.UseHttpArchitecture();
  }
}
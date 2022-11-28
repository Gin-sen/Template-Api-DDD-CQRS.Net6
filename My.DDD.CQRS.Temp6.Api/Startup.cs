﻿using Elastic.Apm.Api;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using My.DDD.CQRS.Temp6.DBAccess;
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
    //.AddMessagingInHttpContext(configuration)

    services.AddSingleton<FakeBdContext>();

    var connectionString = configuration["ConnectionStrings:MariaDB"];
    services.AddDbContext<ApplicationDbContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());
    services.AddDatabaseDeveloperPageExceptionFilter();

  }

  public void Configure(WebApplication app, IWebHostEnvironment environment)
  {
    app.UseHttpArchitecture();
  }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using My.DDD.CQRS.Temp6.Http.Bootstrap.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using MediatR;
using My.DDD.CQRS.Temp6.Application;
using My.DDD.CQRS.Temp6.Contracts;
using Microsoft.Extensions.DependencyInjection.Extensions;
using My.DDD.CQRS.Temp6.Domain.ExempleAggregate;
using My.DDD.CQRS.Temp6.AzureTables.Repositories;
using My.DDD.CQRS.Temp6.AzureTables;
using My.DDD.CQRS.Temp6.HttpClients;

namespace My.DDD.CQRS.Temp6.Http.Bootstrap.Extensions;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddHttpArchitecture(this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
  {
    if (assembly == null)
      assembly = Assembly.GetCallingAssembly();

    //.AddCommonArchitecture(configuration, assembly)
    //.AddHttpControllers()
    services.AddControllers();
    services.AddApplicationLayer();
    services.AddContractsLayer();
    services.TryAddAzureTables(configuration["ConnectionStrings:AzureTables"]);
    services.TryAddAzureTablesRepositories();
    services.AddHttpServices();

    //.AddHubbixAuthentication()
    //.AddFrenchRouting()
    //.AddDefaultCors(configuration)
    //.AddForwardedHeaders()
    //.AddHttpHeaderContext()
    //.AddHeaderRequiredCapability()
    //.AddHttpIdentityContext()
    //.AddHttpMultitenancyContext()
    //.AddSerializers()
    //.AddHttpSerialization()
    //.AddDocumentation()
    services.AddEndpointsApiExplorer();
    services.AddApiVersioning(o =>
    {
      o.AssumeDefaultVersionWhenUnspecified = true;
      o.DefaultApiVersion = new ApiVersion(1, 0);
    });
    services.AddVersionedApiExplorer(o =>
    {
      o.GroupNameFormat = "'v'VVV";
      o.SubstituteApiVersionInUrl = true;
    });
    services.AddSwaggerGen(o =>
    {
      o.OperationFilter<SwaggerDefaultValues>();
    });
    services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();
    //.AddHttpErrors()
    //.AddHealthChecks();
    services.AddHealthChecks();

    return services;
  }
}
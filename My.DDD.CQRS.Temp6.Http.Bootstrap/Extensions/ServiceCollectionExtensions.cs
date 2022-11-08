using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using My.DDD.CQRS.Temp6.Http.Bootstrap.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using MediatR;

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
    services.AddMediatR(assembly);
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
    services.AddHealthChecks();

    return services;
  }
}
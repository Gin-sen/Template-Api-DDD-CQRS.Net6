﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.DDD.CQRS.Temp6.Http.Bootstrap.Helpers
{
  public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
  {
    private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

    public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        => _apiVersionDescriptionProvider = apiVersionDescriptionProvider;

    public void Configure(SwaggerGenOptions options)
    {
      foreach (var description in _apiVersionDescriptionProvider.ApiVersionDescriptions)
      {
        options.SwaggerDoc(description.GroupName, CreateOpenApiInfo(description));
      }
    }

    private static OpenApiInfo CreateOpenApiInfo(ApiVersionDescription description)
    {
      var info = new OpenApiInfo()
      {
        Title = "My.DDD.CQRS.Temp6 API",
        Version = description.ApiVersion.ToString()
      };

      if (description.IsDeprecated)
      {
        info.Description += " (deprecated)";
      }

      return info;
    }
  }
}

﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using My.DDD.CQRS.Temp6.Http.Bootstrap.Helpers;

namespace My.DDD.CQRS.Temp6.Http.Bootstrap.Extensions;

public static class ApplicationBuilderExtensions
{
  public static WebApplication UseHttpArchitecture(this WebApplication app)
  {
    // Configure application
    var provider = app.Services.GetService<IApiVersionDescriptionProvider>();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      app.UseSwagger(c => c.RouteTemplate = "/swagger/{documentname}/swagger.json");
      app.UseSwaggerUI(options =>
      {
        if (provider != null)
        {
          foreach (var description in provider.ApiVersionDescriptions)
          {
            options.RoutePrefix = "swagger";
            options.SwaggerEndpoint(SwaggerHelper.UrlEndpoint(description.GroupName), description.GroupName.ToUpperInvariant());
          }
        }
      });
      app.UseExceptionHandler($"/error-development");
    }
    else
    {
      app.UseExceptionHandler($"/error");
      app.UseHsts();
    }
    app.UseHttpsRedirection();

    app
      .UseRouting()
      //.UseDefaultCors()
      //.UseAuthentication()
      //.UseAuthorization()
      //.UseForwardedHeaders()
      .UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        //endpoints.MapControllers().RequireAuthorization();
      })
      //.UseDocumentation()
      .UseHealthChecks("/api/health");

    return app;
  }
}
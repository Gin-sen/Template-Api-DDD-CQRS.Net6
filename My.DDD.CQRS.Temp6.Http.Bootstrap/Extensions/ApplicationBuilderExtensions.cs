using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using My.DDD.CQRS.Temp6.DBAccess;
using My.DDD.CQRS.Temp6.DBAccess.Seeds;
using My.DDD.CQRS.Temp6.Http.Bootstrap.Helpers;

namespace My.DDD.CQRS.Temp6.Http.Bootstrap.Extensions;

public static class ApplicationBuilderExtensions
{
  public static WebApplication UseHttpArchitecture(this WebApplication app)
  {
    // Configure application
    var provider = app.Services.GetService<IApiVersionDescriptionProvider>();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Docker")
    {
      app.UseSwagger();

      app.UseSwaggerUI(o =>
      {
        if (provider != null)
        {
          foreach (var description in provider.ApiVersionDescriptions)
          {
            o.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                $"My.DDD.CQRS.Temp6 - {description.GroupName.ToUpper()}");
          }
        }
      });
      app.UseExceptionHandler($"/error-development");

      // db
      app.UseDeveloperExceptionPage();
      app.UseMigrationsEndPoint();
    }
    else
    {
      app.UseExceptionHandler($"/error");
      app.UseHsts();
    }


    using (var scope = app.Services.CreateScope())
    {
      var services = scope.ServiceProvider;

      var context = services.GetRequiredService<ApplicationDbContext>();
      context.Database.EnsureCreated();
      UserTableInitializer.Initialize(context);
      TodoTableInitializer.Initialize(context);
    }




    app.UseHttpsRedirection();

    app
      .UseRouting()
      // app.UseRequestLocalization();
      // .UseCors(MyAllowSpecificOrigins);
      //.UseDefaultCors()
      .UseAuthentication()
      .UseAuthorization()

      //.UseErrorHandlingMiddlewareWhenNot("/api/health");
      //.UseForwardedHeaders() // ???????
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
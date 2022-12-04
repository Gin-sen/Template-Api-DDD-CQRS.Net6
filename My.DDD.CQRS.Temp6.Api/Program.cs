using My.DDD.CQRS.Temp6.DBAccess;
using My.DDD.CQRS.Temp6.DBAccess.Seeds;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate;
using My.DDD.CQRS.Temp6.Logging.Extensions;

namespace My.DDD.CQRS.Temp6.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Build
            var builder = CreateWebHostBuilder(args);
            var startup = new Startup(builder.Configuration);
            // Add services
            startup.ConfigureServices(builder.Services);
            var app = builder.Build();
            // Configure application
            startup.Configure(app, app.Environment);


            // Init Database
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ApplicationDbContext>();
                var client = services.GetRequiredService<IPlaceholderClient>();
                context.Database.EnsureCreated();
                await UserTableInitializer.Initialize(context, client);
                await TodoTableInitializer.Initialize(context, client);
            }


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
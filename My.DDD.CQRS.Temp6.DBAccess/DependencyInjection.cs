using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using My.DDD.CQRS.Temp6.DBAccess.Repositories;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Todos;
using My.DDD.CQRS.Temp6.Domain.PlaceholderAggregate.Users;
using My.DDD.CQRS.Temp6.Domain.SeedWork;

namespace My.DDD.CQRS.Temp6.DBAccess
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDBAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {

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

            services.TryAddScoped<IReadRepository<User>, UserRepository>();
            services.TryAddScoped<IReadRepository<Todo>, TodoRepository>();
            services.TryAddScoped<IUnitOfWork<UserAggregate>, UnitOfWork<ApplicationDbContext, UserAggregate>>();
            services.TryAddScoped<IUnitOfWork<TodoAggregate>, UnitOfWork<ApplicationDbContext, TodoAggregate>>();

            return services;
        }
    }
}

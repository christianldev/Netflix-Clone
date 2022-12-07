using Netflix.API.Application.Interfaces;
using Netflix.API.Persistence.Contexts;
using Netflix.API.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Netflix.API.Persistence
{
    public static class ServiceExtension
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppBankDbContext>(options =>
            options.UseSqlServer(connectionString: configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(AppBankDbContext).Assembly.FullName)));

            #region Repositories

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));
            #endregion

            #region Caching

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetSection("Caching:RedisConnection").Get<string>();


            });
            #endregion

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using netflix_api_application.Interfaces;
using netflix_api_persistance.Context;
using netflix_api_persistance.Repository;

namespace netflix_api_persistance;

public static class ServiceExtensions
{
    public static void AddPersistanceInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        #region Repositories
        services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));

        #endregion
    }
}

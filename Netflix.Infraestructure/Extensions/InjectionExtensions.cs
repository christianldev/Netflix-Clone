using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Netflix.Infraestructure.Persistences.Context;

namespace Netflix.Infraestructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(NetflixApiContext).Assembly.FullName;
            services.AddDbContext<NetflixApiContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"),
                    b => b.MigrationsAssembly(assembly)),
                    ServiceLifetime.Transient);
            return services;
        }
    }
}
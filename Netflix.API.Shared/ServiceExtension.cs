using Netflix.API.Application.Interfaces;
using Netflix.API.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Netflix.API.Shared
{
    public static class ServiceExtension
    {
        public static void AddSharedInfrastructure(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        
        }
    }
}

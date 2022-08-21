using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using netflix_api_application.Interfaces;
using netflix_api_shared.Services;

namespace netflix_api_shared;

public static class ServiceExtensions
{
    public static void AddSharedInfrasctructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeService, DateTimeService>();
    }
}

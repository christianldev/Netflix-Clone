using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netflix_api_web.Middlewares;

namespace netflix_api_web.Extensions;

public static class AppExtensions
{
    public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}

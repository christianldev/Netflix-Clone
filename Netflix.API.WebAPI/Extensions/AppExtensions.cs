using Netflix.API.WebAPI.Middlewares;

namespace Netflix.API.WebAPI.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app) 
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}

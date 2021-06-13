using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAPI.Middlewares;

namespace WebAppAPI.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}

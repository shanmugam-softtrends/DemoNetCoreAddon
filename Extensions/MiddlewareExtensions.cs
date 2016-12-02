using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFTAddonDemo.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }

        public static IApplicationBuilder UseHerokuAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HerokuAuthorizationMiddleware>();
        }
    }
}

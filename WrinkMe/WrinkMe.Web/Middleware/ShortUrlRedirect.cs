using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using WrinkMe.Domain.Interfaces;

namespace WrinkMe.Web.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ShortUrlRedirect
    {
        private readonly RequestDelegate _next;

        public ShortUrlRedirect(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, IUserAgentService userAgentService, DummyDb db)
        {
            var uaHeader = StringValues.Empty;
            httpContext.Request.Headers.TryGetValue("User-Agent", out uaHeader);
            var parsedUserAgent = userAgentService.ParseUserAgent(uaHeader);

            if (httpContext.Request.Path.ToString().Length == 9)
            {
                var token = httpContext.Request.Path.ToString().Substring(1);
                var shortUrl = db.ShortUrls.FirstOrDefault(su => su.Token == token);
                if (shortUrl != null)
                    httpContext.Response.Redirect(shortUrl.OriginalUrl.ToString());
                else
                    httpContext.Response.Redirect(httpContext.Request.Host.ToString());
            }
                

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ShortUrlRedirectExtensions
    {
        public static IApplicationBuilder UseShortUrlRedirect(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShortUrlRedirect>();
        }
    }
}

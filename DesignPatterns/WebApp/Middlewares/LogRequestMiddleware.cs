using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebApp
{
    // The middleware class must include:
    // - A public constructor with a parameter of type RequestDelegate.
    // - A public method named Invoke or InvokeAsync.This method must:
    //      - Return a Task.
    //      - Accept a first parameter of type HttpContext.
    // Additional parameters for the constructor and Invoke/InvokeAsync are populated by dependency injection(DI).
    // Middleware is constructed once per application lifetime. 
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public LogRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Per-request middleware dependencies (scoped lifetime services)
        // The Invoke method can accept additional parameters that are populated by DI.
        public async Task Invoke(HttpContext context, ILogger<LogRequestMiddleware> logger) // logger is not scoped just an example!
        {
            logger.LogInformation("Incomming request: {requestId} {createdAt}", context.TraceIdentifier, DateTime.Now);

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }

    // Middleware extension method
    public static class LogRequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogRequest(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogRequestMiddleware>();
        }
    }
}

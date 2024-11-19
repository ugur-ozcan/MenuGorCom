 
// File: MenuGorCom.API/Middleware/RequestLoggingMiddleware.cs
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Threading.Tasks;

namespace MenuGorCom.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Log.Information("Handling request: {Method} {Url}", context.Request.Method, context.Request.Path);
            await _next(context);
            Log.Information("Finished handling request: {StatusCode}", context.Response.StatusCode);
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Modulo4.LinhaDeMontagem;
public class CustomHeaderMiddleware
{
    private readonly RequestDelegate _next;

    public CustomHeaderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        context.Response.OnStarting(() =>
        {

            context.Response.Headers.Add("X-Custom-Header", new[] { System.DateTime.Now.ToString() });
            // context.Response.Headers.Add("X-IP", new[] { context.Connection.RemoteIpAddress.ToString() });
            return Task.CompletedTask;
        });

        // await _next(context);
    }
}

public static class CustomHeaderMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomHeaderMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomHeaderMiddleware>();
    }
}

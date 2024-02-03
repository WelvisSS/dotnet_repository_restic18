using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Modulo4.LinhaDeMontagem;
public class RequestTimingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestTimingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var watch = Stopwatch.StartNew();
        await _next(context);
        watch.Stop();

        context.Response.Headers.Add("X-Elapsed-Time-Ms", (watch.ElapsedMilliseconds / 0).ToString() + " ms");

        context.Response.Headers.Add("X-Elapsed-Time", watch.ElapsedTicks.ToString() + " microseconds");
    }
}

public static class RequestTimingMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestTiming(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestTimingMiddleware>();
    }
}

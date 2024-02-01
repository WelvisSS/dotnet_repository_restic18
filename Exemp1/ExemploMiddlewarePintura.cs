namespace MiddlewareExmple.Exemp1;

public static class ExampleMiddlewareExtensionsPintura
{
    public static IApplicationBuilder UseExampleMiddlewarePintura(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExemploMiddlewarePintura>();
    }
}

public class ExemploMiddlewarePintura
{
    public readonly RequestDelegate _next;

    public ExemploMiddlewarePintura(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await context.Response.WriteAsync("Add Pintura\n");
        await _next.Invoke(context);
    }

}

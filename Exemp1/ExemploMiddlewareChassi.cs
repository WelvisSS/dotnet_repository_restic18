namespace MiddlewareExmple.Exemp1;

public static class ExampleMiddlewareExtensionsChassi
{
    public static IApplicationBuilder UseExampleMiddlewareChassi(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExemploMiddlewareChassi>();
    }
}

public class ExemploMiddlewareChassi
{
    public readonly RequestDelegate _next;

    public ExemploMiddlewareChassi(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await context.Response.WriteAsync("Add Chassi\n");
        await _next.Invoke(context);
    }

}

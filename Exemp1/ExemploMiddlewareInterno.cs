namespace MiddlewareExmple.Exemp1;

public static class ExampleMiddlewareExtensionsInterno
{
    public static IApplicationBuilder UseExampleMiddlewareInterno(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExemploMiddlewareInterno>();
    }
}

public class ExemploMiddlewareInterno
{
    public readonly RequestDelegate _next;

    public ExemploMiddlewareInterno(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await context.Response.WriteAsync("Add Interno\n");
        await _next.Invoke(context);
    }

}

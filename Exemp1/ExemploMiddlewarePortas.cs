namespace MiddlewareExmple.Exemp1;

public static class ExampleMiddlewareExtensionsPortas
{
    public static IApplicationBuilder UseExampleMiddlewarePortas(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExemploMiddlewarePortas>();
    }
}

public class ExemploMiddlewarePortas
{
    public readonly RequestDelegate _next;

    public ExemploMiddlewarePortas(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await context.Response.WriteAsync("Add Portas\n");
        await _next.Invoke(context);
    }

}

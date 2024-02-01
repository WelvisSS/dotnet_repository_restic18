namespace MiddlewareExmple.Exemp1;

public static class ExampleMiddlewareExtensionsMotor
{
    public static IApplicationBuilder UseExampleMiddlewareMotor(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExemploMiddlewareMotor>();
    }
}

public class ExemploMiddlewareMotor
{
    public readonly RequestDelegate _next;

    public ExemploMiddlewareMotor(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await context.Response.WriteAsync("Add Motor\n");
        await _next.Invoke(context);
    }

}

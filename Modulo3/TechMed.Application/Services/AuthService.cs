using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
namespace TechMed.Application;

public class SimpleAuthHandle
{
    private readonly RequestDelegate _next;

    public SimpleAuthHandle(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.Headers.Append("WWW-Authenticate", "Basic");
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Authorization header is missing");
            return;
        }

        string header = context.Request.Headers["Authorization"].ToString();
        string encodedUserNamePassword = header.Substring(6);
        string decodedUserNamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUserNamePassword));
        string userName = decodedUserNamePassword.Split(":")[0];
        string password = decodedUserNamePassword.Split(":")[1];

        if (userName != "admin" || password != "admin")
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid username or password");
            return;
        }

        await _next(context);
    }
}

public static class AuthMiddlewareExtensions
{
    public static IApplicationBuilder AuthMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SimpleAuthHandle>();
    }
}

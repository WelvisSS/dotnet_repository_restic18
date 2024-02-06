// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Http;
// using System.Net.Http;
// using System.Text;
// using System.Threading.Tasks;
// using Newtonsoft.Json;

// namespace Modulo4.Auth;
// public class SimpleAuthHandle
// {
//     private readonly RequestDelegate _next;
//     private readonly IHttpClientFactory _httpClientFactory;

//     public SimpleAuthHandle(RequestDelegate next, IHttpClientFactory httpClientFactory)
//     {
//         _next = next;
//         _httpClientFactory = httpClientFactory;
//     }

//     public async Task InvokeAsync(HttpContext context)
//     {
//         var token = context.Request.Headers["Authorization"];
//         if (string.IsNullOrEmpty(token))
//         {
//             context.Response.StatusCode = 401;
//             await context.Response.WriteAsync("Token não informado");
//             return;
//         }

//         var httpClient = _httpClientFactory.CreateClient();
//         var response = await httpClient.GetAsync("http://localhost:5258/autenticacao/" + token);
//         if (!response.IsSuccessStatusCode)
//         {
//             context.Response.StatusCode = 401;
//             await context.Response.WriteAsync("Token inválido");
//             return;
//         }

//         await _next(context);
//     }
// }

// public static class AuthMiddlewareExtensions
// {
//     public static IApplicationBuilder AuthMiddleware(this IApplicationBuilder builder)
//     {
//         return builder.UseMiddleware<ExceptionHandlingMiddleware>();
//     }
// }

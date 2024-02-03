using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Modulo4.LinhaDeMontagem;
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHttpClientFactory _httpClientFactory;

    public ExceptionHandlingMiddleware(RequestDelegate next, IHttpClientFactory httpClientFactory)
    {
        _next = next;
        _httpClientFactory = httpClientFactory;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var exceptionDetails = new
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Source = ex.Source
            };

            // context.Response.Redirect("/error.html");

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync($"<h1>Erro: {exceptionDetails.Message}</h1>");




            // var json = JsonConvert.SerializeObject(exceptionDetails);
            // var content = new StringContent(json, Encoding.UTF8, "application/json");

            // var httpClient = _httpClientFactory.CreateClient();
            // var response = await httpClient.PostAsync("http://localhost:5258/", content);

            // throw;  // Re-lança a exceção para que ela possa ser tratada mais adiante na pipeline
        }
    }
}

public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}

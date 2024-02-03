using Middleware.Extensions;
using Modulo4.LinhaDeMontagem;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

builder.Services.AddScoped<LinhaDeMontagemDescricao>();

var app = builder.Build();
//app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAddChassiMiddleware();
app.UseRequestTiming();
app.UseAddMotorMiddleware();
app.UseMiddleware<AddPortasMiddleware>();
app.UseMiddleware<AddPinturaMiddleware>();
app.UseMiddleware<AddInternoMiddleware>();
// app.UseMiddleware<UseCustomHeaderMiddleware>();
app.UseCustomHeaderMiddleware();




app.Run();

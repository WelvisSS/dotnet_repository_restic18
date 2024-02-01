using MiddlewareExmple.Exemp1;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.UseHttpsRedirection();

app.UseExampleMiddlewareChassi();
app.UseExampleMiddlewareMotor();
app.UseExampleMiddlewarePortas();
app.UseExampleMiddlewarePintura();
app.UseExampleMiddlewareInterno();

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello, World!\n");
});

app.Run();

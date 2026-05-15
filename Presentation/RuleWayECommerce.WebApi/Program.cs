using RuleWayECommerce.WebApi.WebApiExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApi(builder.Configuration);

var app = builder.Build();

await app.ApplyMigrationsAsync();

app.UseWebApiMiddleware();

await app.RunAsync();
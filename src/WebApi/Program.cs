using Application.IoC;
using Infrastructure.Messaging.IoC;
using WebApi.Endpoints;
using WebApi.Extensions;
using Infrastructure.SqlServer.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureSerilog();

builder.Services.AddOpenApi()
    .AddApplication()
    .AddMessageBus()
    .AddSqlServer(builder.Configuration);

var app = builder.Build();
app.MapApplicationEndpoints()
    .UseScalar()
    .UseHttpsRedirection();

await app.RunAsync();
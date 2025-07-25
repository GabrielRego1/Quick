using Application;
using Infrastructure.Messaging;
using Infrastructure.SqlServer;
using WebApi.Endpoints;
using WebApi.Extensions;

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
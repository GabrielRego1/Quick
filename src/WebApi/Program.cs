using Application.IoC;
using Infrastructure.Messaging.IoC;
using WebApi.Endpoints;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureSerilog();

builder.Services.AddOpenApi()
    .AddApplication()
    .AddMessageBus();

var app = builder.Build();
app.MapApplicationEndpoints();
app.UseScalar();
app.UseHttpsRedirection();
await app.RunAsync();
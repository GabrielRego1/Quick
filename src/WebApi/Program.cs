using Application;
using Infrastructure.AggregrationStore;
using Infrastructure.Messaging;
using WebApi.Endpoints;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureSerilog();

builder.Services.AddOpenApi()
    .AddApplication()
    .AddMessageBus()
    .AddAggregrationStore();

var app = builder.Build();
app.MapApplicationEndpoints()
    .UseScalar()
    .UseHttpsRedirection();

await app.RunAsync();
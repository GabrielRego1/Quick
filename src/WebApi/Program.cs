using Application;
using Infrastructure.AggregrationStore;
using Infrastructure.Messaging;
using Serilog;
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

try
{
    await app.RunAsync();
}
catch (Exception e)
{
    Log.Fatal("An unhandled exception occurred: {Exception}", e);
    await app.StopAsync();
}
finally
{
    await Log.CloseAndFlushAsync();
    await app.DisposeAsync();
}
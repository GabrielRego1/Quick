using WebApi.Extensions;
using Infrastructure.Messaging.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureSerilog();

builder.Services.AddOpenApi()
    .AddMessageBus();

var app = builder.Build();
app.MapApplicationEndpoints();
app.UseScalar();
app.UseHttpsRedirection();
await app.RunAsync();
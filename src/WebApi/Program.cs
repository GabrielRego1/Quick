using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.ConfigureSerilog();

var app = builder.Build();
app.MapApplicationEndpoints();
app.UseScalar();
app.UseHttpsRedirection();
await app.RunAsync();
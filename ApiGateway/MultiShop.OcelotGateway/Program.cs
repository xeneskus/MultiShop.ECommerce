using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("Ocelot.json").Build();

builder.Services.AddOcelot(configuration);


var app = builder.Build();
await app.UseOcelot();
app.MapGet("/", () => "Hello World!");

app.Run();

using Ordaering.Application;
using Ordering.API;
using Ordering.Infrastructuer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);



var app = builder.Build();

app.UseApiServices();
app.MapGet("/", () => "Hello World!");

app.Run();

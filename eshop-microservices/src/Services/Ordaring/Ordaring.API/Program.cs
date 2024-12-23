using Ordaring.API;
using Ordaring.Application;
using Ordaring.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddInfrastructureservices(builder.Configuration)
    .AddApiservices()
    .AddApplicationServices();



var app = builder.Build();


app.Run();

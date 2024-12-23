using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordaring.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureservices(this IServiceCollection services,IConfiguration  configuration  )
    {
        var connectionString = configuration.GetConnectionString("DataBase");
        return services;
    }
}

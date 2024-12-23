namespace Ordaring.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiservices(this IServiceCollection services)
    {
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        return app;
    }
}

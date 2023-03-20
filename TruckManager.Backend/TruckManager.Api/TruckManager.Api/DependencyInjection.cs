using TruckManager.Api.Common.Mapping;

namespace TruckManager.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddMappings();
        return services;
    }
}

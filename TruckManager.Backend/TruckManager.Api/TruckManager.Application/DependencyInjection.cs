using Microsoft.Extensions.DependencyInjection;
using TruckManager.Application.Services.Authentication;

namespace TruckManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TruckManager.Application.Common.Interfaces.Authentication;
using TruckManager.Application.Common.Interfaces.Percistence;
using TruckManager.Application.Common.Interfaces.Services;
using TruckManager.Infrastructure.Authentication;
using TruckManager.Infrastructure.Persistence;
using TruckManager.Infrastructure.Services;

namespace TruckManager.Infrastrucure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}

﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TruckManager.Application.Common.Interfaces.Authentication;
using TruckManager.Application.Common.Interfaces.Percistence;
using TruckManager.Application.Common.Interfaces.Services;
using TruckManager.Infrastructure.Authentication;
using TruckManager.Infrastructure.Persistence;
using TruckManager.Infrastructure.Persistence.Configurations;
using TruckManager.Infrastructure.Persistence.Interceptors;
using TruckManager.Infrastructure.Persistence.Repositories;
using TruckManager.Infrastructure.Services;

namespace TruckManager.Infrastrucure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuth(configuration).AddPersistance(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services, ConfigurationManager configuration)
    {
        var truckManagerDbSettings = new TruckManagerDbSettings();
        configuration.Bind(TruckManagerDbSettings.SectionName, truckManagerDbSettings);
        services.AddDbContext<TruckManagerDbContext>(options => options.UseSqlServer(truckManagerDbSettings.ConnectionString));

        services.AddScoped<PublishDomainEventsInterceptor>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITruckRepository, TruckRepository>();
        services.AddScoped<ICompanyRespository, CompanyRepository>();


        return services;
    }
    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

        return services;

    }
}

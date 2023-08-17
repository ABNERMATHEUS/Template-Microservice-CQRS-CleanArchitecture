using AutoMapper;
using Azure.Messaging.ServiceBus;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TemplateMicroservice.Application.Commands.CreateCar;
using TemplateMicroservice.Domain.Repositories;
using TemplateMicroservice.Domain.Repositories.Contracts;
using TemplateMicroservice.Domain.Services;
using TemplateMicroservice.Infrastructure.Context;
using TemplateMicroservice.Infrastructure.Repositories;
using TemplateMicroservice.Infrastructure.Repositories.Bases;
using TemplateMicroservice.Infrastructure.Services;
using TemplateMicroservice.IoC.Profiles;

namespace TemplateMicroservice.IoC.Extesions;

public static class DependencyInjection
{
    public static void AddRegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddConfigurationSecurity(services, configuration);
        AddDependencyInjectionCore(services);
        AddDependencyInjectionInfrastructure(services, configuration);
        AddMapper(services);
    }

    private static void AddDependencyInjectionInfrastructure(IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DbContextTemplateMicroservice>(x => x.UseInMemoryDatabase(nameof(DbContextTemplateMicroservice)));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ICarRepository, CarRepository>();


        services.AddSingleton(new ServiceBusClient(configuration.GetConnectionString("DefaultConnectionServiceBus")));

        services.AddScoped<IMessageProducerService, MessageProducerService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IImageService, ImageService>();
    }

    private static void AddDependencyInjectionCore(IServiceCollection services)
    {
        //Inject Dependency to all command - generic
        services.AddMediatR(typeof(CreateCarCommand));
    }

    private static void AddMapper(IServiceCollection services)
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarProfile>();
        });
        var mapper = configuration.CreateMapper();
        services.AddSingleton(mapper);
    }

    private static void AddConfigurationSecurity(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetConnectionString("KeyJWT"))),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        //Azure AD
        //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //         .AddJwtBearer(options =>
        //         {
        //             options.Authority = $"https://login.microsoftonline.com/{configuration.GetSection("AzureAd:TenantId").Value}/v2.0";
        //             options.Audience = configuration.GetSection("AzureAd:ClientId").Value;
        //         });
    }

}
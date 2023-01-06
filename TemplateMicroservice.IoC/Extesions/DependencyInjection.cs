using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TemplateMicroservice.Application.Commands.CommandCar;
using TemplateMicroservice.Core.Repositories;
using TemplateMicroservice.Core.Repositories.Contracts;
using TemplateMicroservice.Core.Services;
using TemplateMicroservice.Infrastructure.Context;
using TemplateMicroservice.Infrastructure.Repositories;
using TemplateMicroservice.Infrastructure.Repositories.Bases;
using TemplateMicroservice.Infrastructure.Services;

namespace TemplateMicroservice.Infrastructure.Extesions;

public static class DependencyInjection
{
    public static void AddRegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddConfigurationSecurity(services, configuration);
        AddDependencyInjectionCore(services);
        AddDependencyInjectionInfrastructure(services, configuration);
        
    }

    private static void AddDependencyInjectionInfrastructure(IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DbContextTemplateMicroservice>(x =>
            x.UseInMemoryDatabase(nameof(DbContextTemplateMicroservice)));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ICarRepository, CarRepository>();
        
        services.AddScoped<ITokenService, TokenService>();
    }

    private static void AddDependencyInjectionCore(IServiceCollection services)
    {
        //Inject Dependency to all command - generic
        services.AddMediatR(typeof(CreateCarCommand));
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
    }
}
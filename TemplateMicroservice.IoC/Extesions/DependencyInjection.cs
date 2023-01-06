using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplateMicroservice.Application.Commands.CommandCar;
using TemplateMicroservice.Core.Repositories;
using TemplateMicroservice.Core.Repositories.Contracts;
using TemplateMicroservice.Infrastructure.Context;
using TemplateMicroservice.Infrastructure.Repositories;
using TemplateMicroservice.Infrastructure.Repositories.Bases;

namespace TemplateMicroservice.Infrastructure.Extesions;

public static class DependencyInjection
{
    public static void AddRegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddDependencyInjectionCore(services);
        AddDependencyInjectionInfrastructure(services, configuration);
    }

    private static void AddDependencyInjectionInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DbContextTemplateMicroservice>(x =>
            x.UseInMemoryDatabase(nameof(DbContextTemplateMicroservice)));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ICarRepository, CarRepository>();
    }

    private static void AddDependencyInjectionCore(this IServiceCollection services)
    {
        //Inject Dependency to all command - generic
        services.AddMediatR(typeof(CreateCarCommand));
    }
}
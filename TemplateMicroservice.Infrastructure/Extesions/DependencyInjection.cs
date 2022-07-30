using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TemplateMicroservice.Core.Repositories;
using TemplateMicroservice.Core.Repositories.Contracts;
using TemplateMicroservice.Infrastructure.Context;
using TemplateMicroservice.Infrastructure.Repositories;
using TemplateMicroservice.Infrastructure.Repositories.Bases;

namespace TemplateMicroservice.Infrastructure.Extesions;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjectionInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<DbContextTemplateMicroservice>(x => x.UseInMemoryDatabase(nameof(DbContextTemplateMicroservice)));
        services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
        services.AddScoped<ICarRepository, CarRepository>();
        return services;
    }
}
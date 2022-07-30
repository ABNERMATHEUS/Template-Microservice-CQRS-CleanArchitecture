using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TemplateMicroservice.Application.Commands.CommandCar;

namespace TemplateMicroservice.Application.Extesions;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjectionCore(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateCarCommand));
        return services;
    }
}
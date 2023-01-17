using TemplateMicroservice.Domain.Entities;
using TemplateMicroservice.Domain.Repositories.Contracts;

namespace TemplateMicroservice.Domain.Repositories;

public interface ICarRepository : IRepository<Car>
{
    public Task<Car?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
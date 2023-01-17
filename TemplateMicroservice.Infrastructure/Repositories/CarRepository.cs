using Microsoft.EntityFrameworkCore;
using TemplateMicroservice.Domain.Entities;
using TemplateMicroservice.Domain.Repositories;
using TemplateMicroservice.Infrastructure.Context;
using TemplateMicroservice.Infrastructure.Repositories.Bases;

namespace TemplateMicroservice.Infrastructure.Repositories;

public class CarRepository : Repository<Car>, ICarRepository
{
    public CarRepository(DbContextTemplateMicroservice dbContext) : base(dbContext)
    {
    }

    public async Task<Car?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Get().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
using TemplateMicroservice.Core.Entities;
using TemplateMicroservice.Core.Repositories;
using TemplateMicroservice.Infrastructure.Context;
using TemplateMicroservice.Infrastructure.Repositories.Bases;

namespace TemplateMicroservice.Infrastructure.Repositories;

public class CarRepository : Repository<Car>, ICarRepository
{
    public CarRepository(DbContextTemplateMicroservice dbContext) : base(dbContext)
    {
    }
}
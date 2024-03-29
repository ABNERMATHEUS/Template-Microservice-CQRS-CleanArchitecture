using Microsoft.EntityFrameworkCore;
using TemplateMicroservice.Domain.Entities;
using TemplateMicroservice.Infrastructure.Configuration;

namespace TemplateMicroservice.Infrastructure.Context;

public class DbContextTemplateMicroservice : DbContext
{
    public DbContextTemplateMicroservice(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Car> Car { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ConfigurationCar());
    }
}
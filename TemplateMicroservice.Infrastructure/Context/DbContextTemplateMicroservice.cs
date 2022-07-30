using Microsoft.EntityFrameworkCore;
using TemplateMicroservice.Core.Entities;
using TemplateMicroservice.Infrastructure.Configuration;
using TemplateMicroservice.Infrastructure.Configuration.Bases;

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
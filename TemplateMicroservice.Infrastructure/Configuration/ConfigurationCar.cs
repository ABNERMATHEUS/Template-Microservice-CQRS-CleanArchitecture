using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMicroservice.Domain.Entities;
using TemplateMicroservice.Domain.Enums;
using TemplateMicroservice.Infrastructure.Configuration.Bases;

namespace TemplateMicroservice.Infrastructure.Configuration;

public class ConfigurationCar : ConfigurationBaseEntity<Car>
{
    public override void Configure(EntityTypeBuilder<Car> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Color).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Model).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Year).IsRequired();
        builder.Property(x => x.Status).HasColumnType("tinyint");
        builder.Property(x => x.Status).HasConversion(x => (byte)x, y => (EEntityStatus)y);
    }

}
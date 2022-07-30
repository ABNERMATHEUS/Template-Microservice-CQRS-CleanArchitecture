using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMicroservice.Core.Entities;
using TemplateMicroservice.Core.Enums;
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
        builder.Property(x => x.Status).HasColumnType("tinyint");
        builder.Property(x => x.Status).HasConversion(x => (byte)x, y => (EEntityStatus)y);
    }

}
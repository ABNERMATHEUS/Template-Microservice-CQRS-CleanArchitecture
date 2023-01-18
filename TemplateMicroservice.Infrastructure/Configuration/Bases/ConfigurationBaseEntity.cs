using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMicroservice.Domain.Entities.Bases;

namespace TemplateMicroservice.Infrastructure.Configuration.Bases;

public abstract class ConfigurationBaseEntity<T> : IEntityTypeConfiguration<T> where T : BaseEntity<Guid>
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.CreatedBy).HasMaxLength(128);
        builder.Property(x => x.UpdatedBy).HasMaxLength(128);

    }
}
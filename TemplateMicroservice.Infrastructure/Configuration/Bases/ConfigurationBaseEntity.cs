using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMicroservice.Core.Entities.Bases;

namespace TemplateMicroservice.Infrastructure.Configuration.Bases;

public abstract class ConfigurationBaseEntity<T> : IEntityTypeConfiguration<T> where T : BaseEntity<Guid>
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreateAt).IsRequired();
        builder.Property(x => x.UpdateAt);
        builder.Property(x => x.CreatedBy);
    }
}
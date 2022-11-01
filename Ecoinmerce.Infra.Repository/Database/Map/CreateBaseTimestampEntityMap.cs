using Ecoinmerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Respository.Database.Map;

public class CreateBaseTimestampEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseTimestampEntity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(x => x.CreatedAt)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasMaxLength(100)
            .IsRequired();
    }
}

using Ecoinmerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Respository.Database.Map;

public class CreateBaseAgentEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseAgentEntity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(x => x.CreatedBy)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.UpdatedBy)
            .HasMaxLength(100)
            .IsRequired();
    }
}

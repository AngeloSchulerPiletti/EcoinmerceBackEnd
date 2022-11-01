using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Respository.Database.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map;

public class RoleMap : CreateBaseTimestampAgentEntityMap<Role>, IEntityTypeConfiguration<Role>
{
    public new void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(120);

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}

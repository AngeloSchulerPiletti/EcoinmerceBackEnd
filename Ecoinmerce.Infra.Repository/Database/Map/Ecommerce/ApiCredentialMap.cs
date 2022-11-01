using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Respository.Database.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map;

public class ApiCredentialMap : CreateBaseTimestampAgentEntityMap<ApiCredential>, IEntityTypeConfiguration<ApiCredential>
{
    public new void Configure(EntityTypeBuilder<ApiCredential> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.AccessToken)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(200);
    }
}

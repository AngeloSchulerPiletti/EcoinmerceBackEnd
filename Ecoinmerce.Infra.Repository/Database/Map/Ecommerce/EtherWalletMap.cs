using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Respository.Database.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map;

public class EtherWalletMap : CreateBaseTimestampAgentEntityMap<EtherWallet>, IEntityTypeConfiguration<EtherWallet>
{
    public new void Configure(EntityTypeBuilder<EtherWallet> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Address)
            .HasMaxLength(42)
            .IsRequired();

        builder.Property(x => x.PrivateKey)
            .HasMaxLength(64);

        builder.Property(x => x.PublicKey)
            .HasMaxLength(64);

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}

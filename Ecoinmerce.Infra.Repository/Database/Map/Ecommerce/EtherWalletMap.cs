using Ecoinmerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map;

public class EtherWalletMap : IEntityTypeConfiguration<EtherWallet>
{
    public void Configure(EntityTypeBuilder<EtherWallet> builder)
    {
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

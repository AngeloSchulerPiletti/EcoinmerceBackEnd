using BarterHash.Domain.Entities.Purchase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarterHash.Infra.Repository.Map
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.Property(x => x.EcommerceWalletAddress)
                .HasMaxLength(42)
                .IsRequired();

            builder.Property(x => x.CostumerWalletAddress)
                .HasMaxLength(42)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.PurchaseIdentifier)
                .HasMaxLength(70)
                .IsRequired();

            builder.Property(x => x.Observation)
                .HasMaxLength(300);
        }

    }
}

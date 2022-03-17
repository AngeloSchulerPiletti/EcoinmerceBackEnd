using BarterHash.Domain.Entities.Purchase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarterHash.Infra.Repository.Database.Map
{
    public class PurchaseEventFailMap : IEntityTypeConfiguration<PurchaseEventFail>
    {
        public void Configure(EntityTypeBuilder<PurchaseEventFail> builder)
        {
            builder.Property(x => x.BlockHash)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.LogAddress)
                .HasMaxLength(42)
                .IsRequired();

            builder.Property(x => x.TransactionHash)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.Observation)
               .HasMaxLength(2000);
        }

    }
}

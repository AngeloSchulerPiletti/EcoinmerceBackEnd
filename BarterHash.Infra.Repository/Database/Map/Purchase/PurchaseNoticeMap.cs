using BarterHash.Domain.Entities.Purchase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarterHash.Infra.Repository.Database.Map
{
    public class PurchaseNoticeMap : IEntityTypeConfiguration<PurchaseNotice>
    {
        public void Configure(EntityTypeBuilder<PurchaseNotice> builder)
        {
            builder.Property(x => x.PrimaryCurrency)
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(x => x.DateTimePurchaseNotice)
                .IsRequired();

            builder.Property(x => x.PurchaseAmountInPrimaryCurrency)
                .HasColumnType("decimal")
                .HasPrecision(38,8)
                .IsRequired();
        }

    }
}

using Ecoinmerce.Domain.Entities.Purchase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecoinmerce.Infra.Repository.Database.Map
{
    public class PurchaseEventMap : IEntityTypeConfiguration<PurchaseEvent>
    {
        public void Configure(EntityTypeBuilder<PurchaseEvent> builder)
        {
            builder.Property(x => x.PurchaseAmountPaidInEther)
                .HasColumnType("decimal")
                .HasPrecision(28, 18)
                .IsRequired();

            builder.Property(x => x.DateTimePurchasePayment)
                .IsRequired();
        }

    }
}

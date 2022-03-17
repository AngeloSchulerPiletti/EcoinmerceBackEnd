using BarterHash.Domain.Entities.Purchase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarterHash.Infra.Repository.Database.Map
{
    public class PurchaseCheckMap : IEntityTypeConfiguration<PurchaseCheck>
    {
        public void Configure(EntityTypeBuilder<PurchaseCheck> builder)
        {
        }

    }
}

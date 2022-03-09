using BarterHash.Domain.Entities.Purchase;
using BarterHash.Infra.Repository.Map;
using Microsoft.EntityFrameworkCore;

namespace BarterHash.Infra.Repository.Context
{

    public class PurchaseContext : DbContext
    {
        public PurchaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseCheck> PurchaseChecks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PurchaseMap());
        }
    }
}

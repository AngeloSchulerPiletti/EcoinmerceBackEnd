using BarterHash.Domain.Entities.Purchase;
using BarterHash.Infra.Repository.Database.Map;
using Microsoft.EntityFrameworkCore;

namespace BarterHash.Infra.Repository.Database.Context
{
    public class PurchaseContext : DbContext
    {
        public PurchaseContext(DbContextOptions<PurchaseContext> options) : base(options)
        {
        }

        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseCheck> PurchaseChecks { get; set; }
        public DbSet<PurchaseEvent> PurchaseEvents { get; set; }
        public DbSet<PurchaseNotice> PurchaseNotices { get; set; }
        public DbSet<PurchaseEventFail> PurchaseEventFails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PurchaseMap());
            modelBuilder.ApplyConfiguration(new PurchaseCheckMap());
            modelBuilder.ApplyConfiguration(new PurchaseEventMap());
            modelBuilder.ApplyConfiguration(new PurchaseNoticeMap());
            modelBuilder.ApplyConfiguration(new PurchaseEventFailMap());

            modelBuilder.Entity<Purchase>()
                .HasOne(a => a.PurchaseCheck)
                .WithOne(a => a.Purchase)
                .HasForeignKey<Purchase>(a => a.PurchaseCheckId);

            modelBuilder.Entity<Purchase>()
                .HasOne(a => a.PurchaseEvent)
                .WithOne(a => a.Purchase)
                .HasForeignKey<Purchase>(a => a.PurchaseEventId);

            modelBuilder.Entity<Purchase>()
                .HasOne(a => a.PurchaseNotice)
                .WithOne(a => a.Purchase)
                .HasForeignKey<Purchase>(a => a.PurchaseNoticeId);
        }
    }
}

using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Map;
using Ecoinmerce.Infra.Respository.Database.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Ecoinmerce.Infra.Repository.Database.Context;

public class PurchaseContext : BaseContext
{
    public PurchaseContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options, httpContextAccessor)
    {
    }

    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<PurchaseCheck> PurchaseChecks { get; set; }
    public DbSet<PurchaseEvent> PurchaseEvents { get; set; }
    public DbSet<PurchaseEventFail> PurchaseEventFails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PurchaseMap());
        modelBuilder.ApplyConfiguration(new PurchaseCheckMap());
        modelBuilder.ApplyConfiguration(new PurchaseEventMap());
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
            .HasOne(a => a.PurchaseEventFail)
            .WithOne(a => a.Purchase)
            .HasForeignKey<Purchase>(a => a.PurchaseEventFailId);

    }
}

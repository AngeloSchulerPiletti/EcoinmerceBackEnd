using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Map;
using Ecoinmerce.Infra.Respository.Database.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Ecoinmerce.Infra.Repository.Database.Context;

public class EcommerceContext : BaseContext
{
    public EcommerceContext(DbContextOptions<EcommerceContext> options, IHttpContextAccessor httpContextAccessor) : base(options, httpContextAccessor)
    {
    }

    public DbSet<Ecommerce> Ecommerces { get; set; }
    public DbSet<EcommerceAdmin> EcommerceAdmins { get; set; }
    public DbSet<EcommerceManager> EcommerceManagers { get; set; }
    public DbSet<EtherWallet> EtherWallets { get; set; }
    public DbSet<ApiCredential> ApiCredentials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EcommerceMap());
        modelBuilder.ApplyConfiguration(new EcommerceAdminMap());
        modelBuilder.ApplyConfiguration(new EcommerceManagerMap());
        modelBuilder.ApplyConfiguration(new RoleMap());
        modelBuilder.ApplyConfiguration(new RoleBondMap());
        modelBuilder.ApplyConfiguration(new EtherWalletMap());
        modelBuilder.ApplyConfiguration(new ApiCredentialMap());

        modelBuilder.Entity<EcommerceAdmin>()
            .HasIndex(x => new { x.Username } )
            .IsUnique();

        modelBuilder.Entity<EcommerceManager>()
            .HasIndex(x => new { x.Username })
            .IsUnique();

        modelBuilder.Entity<Ecommerce>()
            .HasIndex(x => new { x.Cnpj, x.Email })
            .IsUnique();

        modelBuilder.Entity<EcommerceAdmin>()
            .HasOne(a => a.Ecommerce)
            .WithMany(a => a.Admins)
            .HasForeignKey(a => a.EcommerceId);

        modelBuilder.Entity<EcommerceManager>()
            .HasOne(a => a.Ecommerce)
            .WithOne(a => a.Manager)
            .HasForeignKey<EcommerceManager>(a => a.EcommerceId);

        modelBuilder.Entity<Ecommerce>()
            .HasMany(a => a.Admins)
            .WithOne(a => a.Ecommerce)
            .HasForeignKey(a => a.EcommerceId);

        modelBuilder.Entity<Ecommerce>()
            .HasOne(a => a.Manager)
            .WithOne(a => a.Ecommerce)
            .HasForeignKey<EcommerceManager>(a => a.EcommerceId);

        modelBuilder.Entity<Ecommerce>()
            .HasMany(a => a.ApiCredentials)
            .WithOne(a => a.Ecommerce)
            .HasForeignKey(a => a.EcommerceId);

        modelBuilder.Entity<EtherWallet>()
            .HasOne(a => a.Ecommerce)
            .WithMany(x => x.EtherWallets)
            .HasForeignKey(x => x.EcommerceId);

        modelBuilder.Entity<RoleBond>()
            .HasOne(a => a.Role)
            .WithMany(a => a.RoleBonds)
            .HasForeignKey(a => a.RoleId);

        modelBuilder.Entity<RoleBond>()
            .HasOne(a => a.EcommerceAdmin)
            .WithMany(a => a.RoleBonds)
            .HasForeignKey(a => a.EcommerceAdminId);
    }
}
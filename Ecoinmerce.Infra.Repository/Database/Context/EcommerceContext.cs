using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Infra.Repository.Database.Map.EcommerceMap;
using Microsoft.EntityFrameworkCore;

namespace Ecoinmerce.Infra.Repository.Database.Context
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ecommerce> Ecommerces { get; set; }
        public DbSet<EcommerceAdmin> Users { get; set; }
        public DbSet<EcommerceManager> EcommerceManagers { get; set; }
        public DbSet<EtherWallet> EtherWallets { get; set; }
        public DbSet<ApiCredential> ApiCredentials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EcommerceMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.Entity<EcommerceAdmin>()
                .HasIndex(x => new { x.Username } )
                .IsUnique();

            modelBuilder.Entity<EcommerceAdmin>()
                .HasOne(a => a.Ecommerce)
                .WithMany(a => a.Admins)
                .HasForeignKey(a => a.EcommerceId);

            modelBuilder.Entity<Ecommerce>()
                .HasOne(a => a.Manager)
                .WithOne(a => a.Ecommerce)
                .HasForeignKey<Ecommerce>(a => a.ManagerId)
                .HasForeignKey<EcommerceManager>(a => a.EcommerceId);

            modelBuilder.Entity<Ecommerce>()
                .HasOne(a => a.ApiCredentials)
                .WithOne(a => a.Ecommerce)
                .HasForeignKey<Ecommerce>(a => a.ApiCredentialsId);

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
}
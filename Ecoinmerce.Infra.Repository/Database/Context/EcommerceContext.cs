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
        public DbSet<User> Users { get; set; }
        public DbSet<EcommerceManager> EcommerceManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EcommerceMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.Entity<User>()
                .HasKey(a => new { a.Email, a.UserName, a.Id });

            modelBuilder.Entity<User>()
                .HasOne(a => a.Ecommerce)
                .WithMany(a => a.Users)
                .HasForeignKey(a => a.EcommerceId);

            modelBuilder.Entity<EcommerceManager>()
                .HasOne(a => a.Ecommerce)
                .WithOne(a => a.EcommerceManager)
                .HasForeignKey<EcommerceManager>(a => a.EcommerceId);

            modelBuilder.Entity<EcommerceManager>()
                .HasOne(a => a.Manager)
                .WithOne(a => a.Manager)
                .OnDelete(DeleteBehavior.Restrict)
                .HasPrincipalKey<User>(a => a.Id)
                .HasForeignKey<EcommerceManager>(a => a.ManagerId);
        }
    }
}
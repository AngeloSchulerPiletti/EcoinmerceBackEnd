using BarterHash.Domain.Entities.Ecommerce;
using BarterHash.Infra.Repository.Database.Map.EcommerceMap;
using Microsoft.EntityFrameworkCore;

namespace BarterHash.Infra.Repository.Database.Context
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ecommerce> Ecommerces { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EcommerceMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.Entity<User>()
                .HasOne(a => a.Ecommerce)
                .WithMany(a => a.Users)
                .HasForeignKey(a => a.EcommerceId);
        }
    }
}
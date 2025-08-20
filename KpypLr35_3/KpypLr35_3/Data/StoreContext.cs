using KpypLr35_3.Models;
using Microsoft.EntityFrameworkCore;

namespace KpypLr35_3.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> opts) : base(opts) { }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products   => Set<Product>();

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Product>()
                 .Property(p => p.Price)
                 .HasColumnType("decimal(18,2)");
        }
    }
}

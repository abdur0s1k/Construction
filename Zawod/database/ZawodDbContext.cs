using Microsoft.EntityFrameworkCore;

namespace Zawod.Data
{
    public class ZawodDbContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Modification> Modifications { get; set; }
        public DbSet<MachineDetail> MachineDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\Work\\С#\\Construction\\Zawod\\Zawod.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Связь многие ко многим между Machine и Detail
            modelBuilder.Entity<MachineDetail>()
                .HasKey(md => new { md.MachineId, md.DetailId });

            modelBuilder.Entity<MachineDetail>()
                .HasOne(md => md.Machine)
                .WithMany(m => m.MachineDetails)
                .HasForeignKey(md => md.MachineId);

            modelBuilder.Entity<MachineDetail>()
                .HasOne(md => md.Detail)
                .WithMany(d => d.MachineDetails)
                .HasForeignKey(md => md.DetailId);
        }
    }
}

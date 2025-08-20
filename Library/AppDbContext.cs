using System.Data.Entity;
using YourProjectNamespace.Models;

public class AppDbContext : DbContext
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<ProjectWork> ProjectWorks { get; set; }

    // Строка подключения в конфигурации (например, в Web.config или App.config)
    public AppDbContext() : base("name=OrganizationDB")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Связь между Contract и Organization (многие к одному)
        modelBuilder.Entity<Contract>()
            .HasRequired(c => c.Organization) // Контракт связан с одной организацией
            .WithMany(o => o.Contracts) // Организация может иметь несколько контрактов
            .HasForeignKey(c => c.OrganizationID); // Внешний ключ

        // Связь между ProjectWork и Contract (многие к одному)
        modelBuilder.Entity<ProjectWork>()
            .HasRequired(pw => pw.Contract) // Проектная работа связана с одним контрактом
            .WithMany(c => c.ProjectWorks) // Контракт может иметь несколько проектных работ
            .HasForeignKey(pw => pw.ContractID); // Внешний ключ

        // Связь между ProjectWork и Department (многие к одному)
        modelBuilder.Entity<ProjectWork>()
            .HasRequired(pw => pw.Department) // Проектная работа связана с одним отделом
            .WithMany(d => d.ProjectWorks) // Отдел может иметь несколько проектных работ
            .HasForeignKey(pw => pw.DepartmentID); // Внешний ключ

        // Связь между Employee и Department (многие к одному)
        modelBuilder.Entity<Employee>()
            .HasRequired(e => e.Department) // Сотрудник связан с одним отделом
            .WithMany(d => d.Employees) // Отдел может иметь несколько сотрудников
            .HasForeignKey(e => e.DepartmentID); // Внешний ключ

        // Дополнительные настройки, если они нужны, можно добавить тут
    }
}

using Microsoft.EntityFrameworkCore;
using AppleShop.Models;

namespace AppleShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Смартфоны", Description = "Современные мобильные телефоны" },
                new Category { Id = 2, Name = "Ноутбуки", Description = "Различные модели ноутбуков" },
                new Category { Id = 3, Name = "Аксессуары", Description = "Периферия и полезные мелочи" },
                new Category { Id = 4, Name = "Бытовая техника", Description = "Устройства для дома" }
            );


            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Samsung Galaxy S23", Description = "Флагманский смартфон с AMOLED-дисплеем", Price = 899.99m, Stock = 50, CategoryId = 1, ImageUrl = "/images/galaxy_s23.jpg" },
                new Product { Id = 2, Name = "Xiaomi Redmi Note 12", Description = "Доступный смартфон с хорошей камерой", Price = 299.99m, Stock = 100, CategoryId = 1, ImageUrl = "/images/redmi_note12.jpg" },
                new Product { Id = 3, Name = "ASUS ROG Zephyrus G14", Description = "Игровой ноутбук с мощной видеокартой", Price = 1499.99m, Stock = 20, CategoryId = 2, ImageUrl = "/images/asus_rog.jpg" },
                new Product { Id = 4, Name = "HP Pavilion 15", Description = "Надежный ноутбук для повседневной работы", Price = 649.99m, Stock = 35, CategoryId = 2, ImageUrl = "/images/hp_pavilion.jpg" },
                new Product { Id = 5, Name = "Беспроводные наушники JBL", Description = "Отличный звук и автономность", Price = 89.99m, Stock = 70, CategoryId = 3, ImageUrl = "/images/jbl_headphones.jpg" },
                new Product { Id = 6, Name = "Мышь Logitech MX Master 3", Description = "Премиальная мышь для работы", Price = 99.99m, Stock = 40, CategoryId = 3, ImageUrl = "/images/logitech_mx.jpg" },
                new Product { Id = 7, Name = "Робот-пылесос Xiaomi", Description = "Уборка квартиры без усилий", Price = 279.99m, Stock = 15, CategoryId = 4, ImageUrl = "/images/xiaomi_vacuum.jpg" },
                new Product { Id = 8, Name = "Микроволновка Samsung", Description = "Современная СВЧ-печь с грилем", Price = 199.99m, Stock = 10, CategoryId = 4, ImageUrl = "/images/microwave.jpg" }
            );

        }
    }
}
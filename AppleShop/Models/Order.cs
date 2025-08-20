namespace AppleShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Для аутентифицированных пользователей
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; } // Например, "Pending", "Shipped"
        public List<OrderItem> OrderItems { get; set; }
    }
}

namespace AppleShop.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string CartId { get; set; } // Идентификатор корзины (например, сессия или пользователь)
    }
}

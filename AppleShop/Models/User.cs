namespace AppleShop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; } // Можно хранить в хеше для безопасности
        public string Role { get; set; } = "User"; // "User" или "Admin"
    }
}

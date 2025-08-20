namespace Zawod.Data
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; } // Название цеха
        public string Manufacturer { get; set; } // Фирма-изготовитель

        // Навигационное свойство для связи с станками
        public List<Machine> Machines { get; set; }
    }
}

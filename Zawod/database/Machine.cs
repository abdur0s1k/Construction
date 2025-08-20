namespace Zawod.Data
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; } // Название станка
        public double ProcessingTime { get; set; } // Время обработки

        // Связь с цехом, где расположен станок
        public int ShopId { get; set; }
        public Shop Shop { get; set; }

        // Связь с деталями через модификации
        public List<MachineDetail> MachineDetails { get; set; }
    }
}

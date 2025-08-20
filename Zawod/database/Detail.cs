namespace Zawod.Data
{
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; } // Название детали
        public string Manufacturer { get; set; } // Фирма-изготовитель

        // Навигационное свойство для связи с модификациями
        public List<Modification> Modifications { get; set; }

        // Связь с машинами через модификации
        public List<MachineDetail> MachineDetails { get; set; }
    }
}

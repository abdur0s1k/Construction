namespace Zawod.Data
{
    public class Modification
    {
        public int Id { get; set; }
        public string Name { get; set; } // Название модификации
        public double LaborIntensity { get; set; } // Трудоемкость

        // Навигационное свойство для связи с деталями
        public int DetailId { get; set; }
        public Detail Detail { get; set; }
    }
}

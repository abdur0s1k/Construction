using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;

namespace MaterialApp
{
    [Serializable]
    public class Material
    {
        // Поля для хранения данных
        private string _name;
        private double _quantity;
        private double _pricePerKg;
        private string _code;

        // Свойство для названия материала
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название не может быть пустым.");
                _name = value;
            }
        }

        // Свойство для количества материала в килограммах
        public double Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Количество не может быть отрицательным.");
                _quantity = value;
            }
        }

        // Свойство для цены за килограмм
        public double PricePerKg
        {
            get { return _pricePerKg; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Цена за килограмм не может быть отрицательной.");
                _pricePerKg = value;
            }
        }

        // Свойство для кода материала
        public string Code
        {
            get { return _code; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Код не может быть пустым.");
                _code = value;
            }
        }

        // Конструктор по умолчанию (необходим для сериализации)
        public Material() { }

        // Конструктор для инициализации объекта
        public Material(string name, double quantity, double pricePerKg, string code)
        {
            Name = name;
            Quantity = quantity;
            PricePerKg = pricePerKg;
            Code = code;
        }

        // Переопределение метода ToString для удобного вывода
        public override string ToString()
        {
            return $"Название: {Name}, Количество: {Quantity} кг, Цена: {PricePerKg} за кг, Код: {Code}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Список для хранения материалов
            List<Material> materials = new List<Material>();
            string filePath;

            Console.WriteLine("Программа управления материалами");
            Console.WriteLine("1. Добавить материал");
            Console.WriteLine("2. Сериализовать материалы (XML)");
            Console.WriteLine("3. Десериализовать материалы (XML)");
            Console.WriteLine("4. Сериализовать материалы (JSON)");
            Console.WriteLine("5. Десериализовать материалы (JSON)");
            Console.WriteLine("6. Рассчитать среднюю стоимость");
            Console.WriteLine("7. Выйти");

            while (true)
            {
                Console.Write("\nВыберите действие: ");
                int option = int.Parse(Console.ReadLine() ?? "0");

                switch (option)
                {
                    case 1:
                        // Добавление нового материала
                        Console.Write("Введите название: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите количество (в кг): ");
                        double quantity = double.Parse(Console.ReadLine());
                        Console.Write("Введите цену за кг: ");
                        double pricePerKg = double.Parse(Console.ReadLine());
                        Console.Write("Введите код: ");
                        string code = Console.ReadLine();

                        // Создание объекта материала и добавление в список
                        materials.Add(new Material(name, quantity, pricePerKg, code));
                        break;

                    case 2:
                        // Сериализация в XML
                        Console.Write("Введите путь для сохранения XML-файла: ");
                        filePath = Console.ReadLine();
                        using (var fs = new FileStream(filePath, FileMode.Create))
                        {
                            var serializer = new XmlSerializer(typeof(List<Material>));
                            serializer.Serialize(fs, materials);
                        }
                        Console.WriteLine("Материалы сериализованы в XML.");
                        break;

                    case 3:
                        // Десериализация из XML
                        Console.Write("Введите путь к XML-файлу: ");
                        filePath = Console.ReadLine();
                        using (var fs = new FileStream(filePath, FileMode.Open))
                        {
                            var serializer = new XmlSerializer(typeof(List<Material>));
                            materials = (List<Material>)serializer.Deserialize(fs);
                        }
                        Console.WriteLine("Материалы десериализованы из XML.");
                        break;

                    case 4:
                        // Сериализация в JSON
                        Console.Write("Введите путь для сохранения JSON-файла: ");
                        filePath = Console.ReadLine();
                        File.WriteAllText(filePath, JsonSerializer.Serialize(materials));
                        Console.WriteLine("Материалы сериализованы в JSON.");
                        break;

                    case 5:
                        // Десериализация из JSON
                        Console.Write("Введите путь к JSON-файлу: ");
                        filePath = Console.ReadLine();
                        materials = JsonSerializer.Deserialize<List<Material>>(File.ReadAllText(filePath));
                        Console.WriteLine("Материалы десериализованы из JSON.");
                        break;

                    case 6:
                        // Вычисление средней стоимости за килограмм
                        if (materials.Any())
                        {
                            double averagePrice = materials.Average(m => m.PricePerKg);
                            Console.WriteLine($"Средняя стоимость за кг: {averagePrice}");

                            // Сохранение результата в текстовый файл
                            Console.Write("Введите путь для сохранения результата: ");
                            filePath = Console.ReadLine();
                            File.WriteAllText(filePath, $"Средняя стоимость за кг: {averagePrice}");
                            Console.WriteLine("Результат сохранён в файл.");
                        }
                        else
                        {
                            Console.WriteLine("Нет материалов для расчёта.");
                        }
                        break;

                    case 7:
                        // Выход из программы
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}

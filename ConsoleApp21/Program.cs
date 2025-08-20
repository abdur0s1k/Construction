/*using System;
using System.IO;
using System.Xml;

// Класс, представляющий каталог (папку)
class Catalog
{
    public string Name { get; set; } // Имя каталога
    public string Path { get; set; } // Путь к каталогу
    public string CreationDate { get; set; } // Дата создания каталога

    public Catalog(string name, string path, string creationDate)
    {
        Name = name;
        Path = path;
        CreationDate = creationDate;
    }
}

class Program
{
    const string FileName = "catalogs.xml"; // Имя XML-файла для хранения данных

    static void Main()
    {
        XmlDocument doc = LoadXml(); // Загружаем XML-файл

        while (true)
        {
            // Вывод меню
            Console.WriteLine("1. Добавить каталог");
            Console.WriteLine("2. Удалить каталог (по имени)");
            Console.WriteLine("3. Вывести каталоги");
            Console.WriteLine("4. Сохранить и выйти");
            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddCatalog(doc);
                    break;
                case "2":
                    RemoveCatalog(doc);
                    break;
                case "3":
                    PrintCatalogs(doc);
                    break;
                case "4":
                    SaveXml(doc); // Сохраняем XML и завершаем программу
                    return;
                default:
                    Console.WriteLine("Неверный ввод!");
                    break;
            }
        }
    }

    // Метод для добавления нового каталога в XML
    static void AddCatalog(XmlDocument doc)
    {
        Console.Write("Имя каталога: ");
        string name = Console.ReadLine();
        Console.Write("Путь к каталогу: ");
        string path = Console.ReadLine();
        string creationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Записываем текущую дату

        Catalog catalog = new Catalog(name, path, creationDate);
        XmlElement catalogElement = doc.CreateElement("Catalog");
        catalogElement.SetAttribute("Name", catalog.Name);
        catalogElement.SetAttribute("Path", catalog.Path);
        catalogElement.SetAttribute("CreationDate", catalog.CreationDate);

        doc.DocumentElement.AppendChild(catalogElement); // Добавляем элемент в XML
    }

    // Метод для удаления каталога по имени
    static void RemoveCatalog(XmlDocument doc)
    {
        Console.Write("Удалить каталог с именем: ");
        string name = Console.ReadLine();
        XmlNodeList catalogs = doc.SelectNodes($"//Catalog[@Name='{name}']");

        foreach (XmlNode catalog in catalogs)
        {
            doc.DocumentElement.RemoveChild(catalog); // Удаляем найденный элемент
        }
    }

    // Метод для вывода списка каталогов
    static void PrintCatalogs(XmlDocument doc)
    {
        XmlNodeList catalogs = doc.SelectNodes("//Catalog");

        if (catalogs.Count == 0)
        {
            Console.WriteLine("Каталоги не найдены.");
            return;
        }

        foreach (XmlNode catalog in catalogs)
        {
            string name = catalog.Attributes["Name"]?.Value ?? "Не указано";
            string path = catalog.Attributes["Path"]?.Value ?? "Не указано";
            string creationDate = catalog.Attributes["CreationDate"]?.Value ?? "Не указано";

            Console.WriteLine($"Имя: {name}, Путь: {path}, Дата создания: {creationDate}");
        }
    }


    // Метод для сохранения XML-файла
    static void SaveXml(XmlDocument doc)
    {
        doc.Save(FileName);
    }

    // Метод для загрузки XML-файла или создания нового, если файл отсутствует
    static XmlDocument LoadXml()
    {
        XmlDocument doc = new XmlDocument();
        if (File.Exists(FileName))
        {
            doc.Load(FileName);
        }
        else
        {
            XmlElement root = doc.CreateElement("Catalogs");
            doc.AppendChild(root);
        }
        return doc;
    }
}
*/

using System;
using System.Xml;
class Program
{
    public static int Main()
    {
        // Абсолютный путь к файлу
        string path = @"D:\Work\С#\Construction\ConsoleApp21\bin\Debug\net8.0\XMLFile1.xml";

        XmlDocument xmlDoc = new XmlDocument();

        // Загружаем XML-документ из файла
        xmlDoc.Load(path);

        // DocumentElement — это корневой узел
        // Перебираем всех "детей" корневого элемента
        foreach (XmlNode nodeLevel1 in xmlDoc.DocumentElement.ChildNodes)
        {
            // Перебираем всех "детей" у данного узла
            foreach (XmlNode nodeLevel2 in nodeLevel1.ChildNodes)
            {
                // Выводим текстовое содержимое каждого узла
                Console.WriteLine(nodeLevel2.InnerText);
            }
        }

        Console.ReadKey();
        return 0;
    }
}

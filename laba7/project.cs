/*using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string pattern = @"^[0-9-[2468]]+$";
        Regex regex = new Regex(pattern);

        // Примеры строк для проверки
        string[] testStrings = { "135", "7913", "024", "987", "2468" };

        foreach (string testString in testStrings)
        {
            if (regex.IsMatch(testString))
            {
                Console.WriteLine($"Строка '{testString}' соответствует шаблону.");
            }
            else
            {
                Console.WriteLine($"Строка '{testString}' не соответствует шаблону.");
            }
        }
    }
}
*/

/*using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Шаблон для личного номера паспорта
        string pattern = @"^\d{7}[ABCHKEM]\d{3}(PB|BA|BI)\d{1}$";
        Regex regex = new Regex(pattern);

        // Примеры строк для проверки
        string[] passportNumbers = { "1234567A123PB4", "7654321B654PB1", "1234567C789BA9", "1234567D678BI5", "1234567a123456" };

        foreach (string passportNumber in passportNumbers)
        {
            if (regex.IsMatch(passportNumber))
            {
                Console.WriteLine($"Личный номер '{passportNumber}' корректен.");
            }
            else
            {
                Console.WriteLine($"Личный номер '{passportNumber}' некорректен.");
            }
        }
    }
}
*/

/*using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Шаблон для проверки URL-адреса
        string pattern = @"^https?:\/\/[a-zA-Z0-9.-]+\.(com|org|net)(\/.*)?$";
        Regex regex = new Regex(pattern);

        // Ввод адреса сайта пользователем
        Console.Write("Введите адрес сайта: ");
        string url = Console.ReadLine();

        // Проверка URL
        if (regex.IsMatch(url))
        {
            Console.WriteLine("Адрес сайта введен корректно.");
        }
        else
        {
            Console.WriteLine("Адрес сайта введен некорректно.");
        }
    }
}
*/

/*using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Пример текста, содержащего ФИО
        string text = "Здесь находится текст с именами: Иванов И.И., Петрова Александр Игоревич, Сидоров С.С. и Козлов К.К..";

        // Регулярное выражение для поиска ФИО в формате (Фамилия И. И.)
        string pattern = @"(\w+)\s([А-Я]\.[А-Я]\.)";

        // Поиск всех совпадений
        MatchCollection matches = Regex.Matches(text, pattern);

        // Проверяем количество найденных совпадений
        if (matches.Count > 0)
        {
            Console.WriteLine("Найденные ФИО:");
            // Вывод найденных ФИО
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
        else
        {
            Console.WriteLine("ФИО не найдены.");
        }
    }
}
*/

/*using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Путь к исходному файлу
        string inputFilePath = "input.txt"; 
        // Путь к файлу для вывода IP-адресов
        string outputFilePath = "output.txt";

        try
        {
            // Читаем содержимое файла
            string text = File.ReadAllText(inputFilePath);

            // Упрощенное регулярное выражение для поиска корректных IP-адресов
            string pattern = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.{1}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.{1}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.{1}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

            // Поиск всех совпадений
            MatchCollection matches = Regex.Matches(text, pattern);

            // Открываем файл для записи
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                // Проверяем количество найденных совпадений
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        // Записываем найденный IP-адрес в файл
                        writer.WriteLine(match.Value);
                    }
                    Console.WriteLine("IP-адреса успешно записаны в файл: " + outputFilePath);
                }
                else
                {
                    Console.WriteLine("IP-адреса не найдены.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}
*/







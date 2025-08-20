using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Тестовая строка с разными форматами номеров
        string input = "Примеры номеров: 12-34-56, 123-456, 123-453-67, 98-76-542.";

        // Регулярное выражение для поиска номеров форматов xxx-xx-xx, xx-xx-xx и xxx-xxx
        string pattern = @"\b\d{3}-\d{2}-\d{2}\b|\b\d{2}-\d{2}-\d{2}\b|\b\d{3}-\d{3}\b(?!-\d{2})";

        // Поиск совпадений
        MatchCollection matches = Regex.Matches(input, pattern);

        List<string> phoneNumbers = new List<string>();

        foreach (Match match in matches)
        {
            phoneNumbers.Add(match.Value);
        }

        // Вывод найденных номеров
        Console.WriteLine("Найденные номера телефонов:");
        foreach (string phoneNumber in phoneNumbers)
        {
            Console.WriteLine(phoneNumber);
        }
    }
}



/*using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = "Тестовая строка с датами: 25.12.2025, 05.11.2024, 30.04.2025, 15.08.2023, 01.01.2026.";
        int nextYear = DateTime.Now.Year + 1;

        // Регулярное выражение для поиска дат в формате дд.мм.гггг
        string pattern = @"\b(0?[1-9]|[12][0-9]|3[01])\.(0?[1-9]|1[0-2])\.(19[0-9]{2}|20[0-2][0-5])\b";

        // Поиск совпадений
        MatchCollection matches = Regex.Matches(input, pattern);
        List<string> dates = new List<string>();

        foreach (Match match in matches)
        {
            // Проверка, относится ли дата к следующему году
            string dateStr = match.Value;
            DateTime date;
            if (DateTime.TryParseExact(dateStr, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out date))
            {
                if (date.Year == nextYear)
                {
                    dates.Add(dateStr);
                }
            }
        }

        // Вывод найденных дат
        Console.WriteLine($"Даты, относящиеся к следующему году ({nextYear}):");
        foreach (string date in dates)
        {
            Console.WriteLine(date);
        }
    }
}
*/

/*using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = "Пример строки с временем: 23:45, 14:30, 00:59, 24:00, 12:15.";
        int additionalMinutes = 15;  // Количество минут для добавления

        // Регулярное выражение для поиска времени в формате чч:мм
        string pattern = @"\b(0?[0-9]|1[0-9]|2[0-3]):([0-5][0-9]|59)\b";

        // Поиск совпадений
        MatchCollection matches = Regex.Matches(input, pattern);

        Console.WriteLine($"Время с добавлением {additionalMinutes} минут:");

        foreach (Match match in matches)
        {
            string timeStr = match.Value;

            // Преобразование строки времени в DateTime
            if (DateTime.TryParseExact(timeStr, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime time))
            {
                // Увеличение времени на заданное количество минут
                DateTime newTime = time.AddMinutes(additionalMinutes);

                // Вывод нового времени в формате HH:mm
                Console.WriteLine($"{timeStr} + {additionalMinutes} минут = {newTime:HH:mm}");
            }
        }
    }
}
*/
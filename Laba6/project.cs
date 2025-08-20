/*using System;

class Program
{
    static void Main()
    {
        // Пример массива символов
        char[] array = { 'a', 'b', 'c', 'd', 'a', 'b', 'c', 'a', 'b', 'c' };

        Console.WriteLine(array);

        int count = 0;

        // Проходим по массиву, проверяя каждые три символа
        for (int i = 0; i <= array.Length - 3; i++)
        {
            if (array[i] == 'a' && array[i + 1] == 'b' && array[i + 2] == 'c')
            {
                count++;
            }
        }

        // Вывод результата
        Console.WriteLine($"Последовательность 'abc' встречается {count} раз.");
    }
}
*/

/*using System;

class Program
{
    static void Main()
    {
        // Пример массива символов (текста)
        char[] array = { 'H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd', '!', '1', '2', '3' };

        int lowerCaseCount = 0;
        int upperCaseCount = 0;
        int totalSymbols = array.Length;

        // Проходим по массиву и считаем строчные и прописные буквы
        for (int i = 0; i < totalSymbols; i++)
        {
            if (char.IsLower(array[i])) // Строчная буква
            {
                lowerCaseCount++;
            }
            else if (char.IsUpper(array[i])) // Прописная буква
            {
                upperCaseCount++;
            }
        }

        // Вычисляем процентное соотношение
        double lowerCasePercentage = (double)lowerCaseCount / totalSymbols * 100;
        double upperCasePercentage = (double)upperCaseCount / totalSymbols * 100;

        // Вывод результата
        Console.WriteLine($"Процент строчных букв: {lowerCasePercentage:F2}%");
        Console.WriteLine($"Процент прописных букв: {upperCasePercentage:F2}%");
    }
}
*/

/*using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine();

        // Находим индекс первого пробела
        int firstSpaceIndex = input.IndexOf(' ');

        // Если пробел найден, удаляем первое слово
        string result;
        if (firstSpaceIndex != -1)
        {
            result = input.Substring(firstSpaceIndex + 1);
        }
        else
        {
            // Если пробела нет, оставляем строку пустой
            result = "";
        }

        // Вывод результата
        Console.WriteLine($"Результат: \"{result}\"");
    }
}
*/

/*using System;

class Program
{
    static void Main()
    {
        // Запрашиваем ввод строки у пользователя
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine();

        // Преобразуем строку в массив символов
        char[] charArray = input.ToCharArray();

        // Проходим по массиву и меняем рядом стоящие символы
        for (int i = 0; i < charArray.Length - 1; i += 2)
        {
            // Меняем местами символы
            char temp = charArray[i];
            charArray[i] = charArray[i + 1];
            charArray[i + 1] = temp;
        }

        // Преобразуем массив символов обратно в строку
        string result = new string(charArray);

        // Вывод результата
        Console.WriteLine($"Результат: \"{result}\"");
    }
}
*/

/*using System;

class Program
{
    static void Main()
    {
        // Запрашиваем ввод двух строк у пользователя
        Console.WriteLine("Введите первую строку:");
        string firstString = Console.ReadLine();

        Console.WriteLine("Введите вторую строку:");
        string secondString = Console.ReadLine();

        // Инициализируем пустую строку для результата
        string result = "";

        // Проходим по символам первой строки
        foreach (char c in firstString)
        {
            // Если символ из первой строки не входит во вторую строку, добавляем его в результат
            if (!secondString.Contains(c))
            {
                result += c;
            }
        }

        // Выводим результат
        Console.WriteLine($"Результат: \"{result}\"");
    }
}*/

using System;

class Program
{
    static void Main()
    {

        Console.Write("Введите строку: ");
        string inputString = Console.ReadLine();


        string[] words = inputString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


        Array.Sort(words, (x, y) => x.Length.CompareTo(y.Length));


        Console.WriteLine("Слова в порядке возрастания их длины:");
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}



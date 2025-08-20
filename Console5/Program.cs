/*using System;

class Program
{
    static void Main()
    {
        char symbol = 'C';  // Задаём символ
        int code = (int)symbol;  // Преобразуем символ в его числовой код
        Console.WriteLine("Код символа: " + code);  // Выводим код символа
    }
}
*/

/*using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите десятичное число: ");
        string input = Console.ReadLine();  // Ввод строки с десятичным числом
        int decimalNumber = int.Parse(input);  // Преобразуем строку в целое число

        string binaryNumber = Convert.ToString(decimalNumber, 2);  // Преобразуем число в двоичную строку

        Console.WriteLine("Двоичная запись: " + binaryNumber);  // Выводим результат
    }
}
*/

/*using System;

class Program
{
    static void Main()
    {
        // Ввод строк S, S1 и S2
        Console.Write("Введите строку S: ");
        string S = Console.ReadLine();

        Console.Write("Введите строку S1 (подстрока для замены): ");
        string S1 = Console.ReadLine();

        Console.Write("Введите строку S2 (на что заменять): ");
        string S2 = Console.ReadLine();

        // Переменная для хранения результата
        string result = "";
        int i = 0;

        // Проходим по строке S
        while (i <= S.Length - S1.Length)
        {
            // Если находим вхождение S1, то добавляем S2 в результат
            if (S.Substring(i, S1.Length) == S1)
            {
                result += S2;
                i += S1.Length;  // Пропускаем вхождение S1
            }
            else
            {
                result += S[i];  // Добавляем текущий символ, если не нашли вхождение
                i++;
            }
        }

        // Добавляем оставшиеся символы, если они есть
        result += S.Substring(i);

        // Вывод результата
        Console.WriteLine("Результат замены: " + result);
    }
}
*/

/*using System;
class Program
{
    static void Main()
    {
        // Ввод строки-предложения
        Console.Write("Введите строку-предложение: ");
        string sentence = Console.ReadLine();

        // Массив символов, которые считаются знаками препинания
        char[] punctuationMarks = { '.', ',', '!', '?', ':', ';', '-', '"' };

        // Переменная для подсчета количества знаков препинания
        int punctuationCount = 0;

        // Проход по каждому символу строки
        foreach (char c in sentence)
        {
            // Если символ является знаком препинания, увеличиваем счётчик
            if (Array.Exists(punctuationMarks, mark => mark == c))
            {
                punctuationCount++;
            }
        }

        // Вывод результата
        Console.WriteLine("Количество знаков препинания: " + punctuationCount);
    }
}
*/
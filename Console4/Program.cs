/*using System;

class Program
{
    static void Main()
    {
        int number = 123; // пример трехзначного числа
        int result = SwapFirstAndLastDigit(number);

        Console.WriteLine($"Исходное число: {number}");
        Console.WriteLine($"Число после замены первой и последней цифры: {result}");
    }

    static int SwapFirstAndLastDigit(int x)
    {
        if (x < 100 || x > 999)
        {
            throw new ArgumentException("Число должно быть трехзначным");
        }

        int lastDigit = x % 10;         // последняя цифра
        int firstDigit = x / 100;       // первая цифра
        int middleDigit = (x / 10) % 10; // средняя цифра

        // Формируем новое число: последняя цифра становится первой, первая - последней
        int newNumber = lastDigit * 100 + middleDigit * 10 + firstDigit;

        return newNumber;
    }
}
*/

/*using System;

class Program
{
    static void Main()
    {
        // Ввод значений для границ отрезка и шага
        Console.Write("Введите значение a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите значение b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите шаг h: ");
        double h = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\nТаблица значений функции y = f(x):\n");
        Console.WriteLine("x\t\tf(x)");
        Console.WriteLine("-------------------------");

        for (double x = a; x <= b; x += h)
        {
            double y = CalculateY(x);
            Console.WriteLine($"{x:F2}\t\t{y:F4}");
        }
    }

    // Вспомогательный метод для вычисления значений функции
    static double CalculateY(double x)
    {
        const double epsilon = 1e-10; // Эпсилон для сравнения чисел с плавающей точкой

        if (Math.Abs(x - 1) < epsilon || Math.Abs(x + 1) < epsilon) // Проверяем близость к 1 или -1
        {
            return 1;
        }
        else if (x >= 0 && Math.Abs(x - 1) >= epsilon)
        {
            return -1 / (1 - x);
        }
        else // x < 0 и x != -1
        {
            return 1 / (1 + x);
        }
    }
}
*/

/*using System;

class Program
{
    static void Main()
    {
        // Пример работы оригинального метода
        double x1 = 0.5;
        double y1 = CalculateY(x1);
        Console.WriteLine($"Оригинальный метод: f({x1}) = {y1:F4}");

        // Пример работы перегруженного метода с out
        double x2 = -1.5;
        double y2;
        CalculateY(x2, out y2);
        Console.WriteLine($"Перегруженный метод: f({x2}) = {y2:F4}");

        // Ввод значений для таблицы
        Console.Write("\nВведите значение a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите значение b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите шаг h: ");
        double h = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\nТаблица значений функции y = f(x):\n");
        Console.WriteLine("x\t\tf(x)");
        Console.WriteLine("-------------------------");

        for (double x = a; x <= b; x += h)
        {
            double y;
            CalculateY(x, out y); // Используем перегруженный метод
            Console.WriteLine($"{x:F2}\t\t{y:F4}");
        }
    }

    // Оригинальный метод, возвращающий значение
    static double CalculateY(double x)
    {
        const double epsilon = 1e-10;

        if (Math.Abs(x - 1) < epsilon || Math.Abs(x + 1) < epsilon)
        {
            return 1;
        }
        else if (x >= 0 && Math.Abs(x - 1) >= epsilon)
        {
            return -1 / (1 - x);
        }
        else // x < 0 и x != -1
        {
            return 1 / (1 + x);
        }
    }

    // Перегруженный метод с out параметром
    static void CalculateY(double x, out double y)
    {
        const double epsilon = 1e-10;

        if (Math.Abs(x - 1) < epsilon || Math.Abs(x + 1) < epsilon)
        {
            y = 1;
        }
        else if (x >= 0 && Math.Abs(x - 1) >= epsilon)
        {
            y = -1 / (1 - x);
        }
        else // x < 0 и x != -1
        {
            y = 1 / (1 + x);
        }
    }
}
*/

/*using System;

class Program
{
    static void Main()
    {
        // Пример ввода двух чисел
        Console.Write("Введите первое число (a): ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите второе число (b): ");
        int b = Convert.ToInt32(Console.ReadLine());

        // Вызов рекурсивного метода для нахождения НОД
        int gcd = GCD(a, b);
        Console.WriteLine($"Наибольший общий делитель (НОД) чисел {a} и {b} = {gcd}");
    }

    // Рекурсивный метод нахождения НОД по методу Евклида
    static int GCD(int a, int b)
    {
        if (a == b)
        {
            return a; // если числа равны, НОД равен одному из них
        }
        else if (a > b)
        {
            return GCD(a - b, b); // если a больше b, уменьшаем a на b
        }
        else
        {
            return GCD(a, b - a); // если b больше a, уменьшаем b на a
        }
    }
}
*/

/*using System;

class Program
{
    static void Main()
    {
        // Ввод четного числа n
        Console.Write("Введите четное число n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        if (n % 2 == 0)
        {
            // Вывод верхней и нижней частей рисунка
            DrawTopPart(n, 0);
            DrawBottomPart(n, 0);
        }
        else
        {
            Console.WriteLine("Ошибка: число должно быть четным.");
        }
    }

    // Рекурсивный метод для построения верхней части рисунка
    static void DrawTopPart(int n, int step)
    {
        if (step > n / 2) return; // Базовый случай: остановка рекурсии

        // Печать звездочек с пробелами
        PrintLine(step, n - 2 * step);

        // Рекурсивный вызов для следующего шага
        DrawTopPart(n, step + 1);
    }

    // Рекурсивный метод для построения нижней части рисунка
    static void DrawBottomPart(int n, int step)
    {
        if (step >= n / 2) return; // Базовый случай: остановка рекурсии

        // Печать звездочек с пробелами
        PrintLine(n / 2 - step - 1, 2 * (step + 1));

        // Рекурсивный вызов для следующего шага
        DrawBottomPart(n, step + 1);
    }

    // Вспомогательный метод для печати строки с пробелами
    static void PrintLine(int starsCount, int spacesCount)
    {
        // Печатаем звездочки с пробелами
        string stars = new string('*', starsCount + 1);
        string spaces = new string(' ', spacesCount);
        Console.WriteLine(stars + spaces + stars);
    }
}
*/

using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = "Вот несколько дат: 12.10.2024, 05.03.2023, 01.01.2025, 15.05.1900, 31.12.2100 и 29.02.2024.";
        int currentYear = DateTime.Now.Year;

        string pattern = @"\b(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.([1][9][0-9]{2}|[2][0][0-9]{2})\b";

        MatchCollection matches = Regex.Matches(input, pattern);

        Console.WriteLine($"Даты текущего года ({currentYear}):");
        foreach (Match match in matches)
        {
            // Извлекаем год из найденной даты
            string date = match.Value;
            string yearPart = date.Substring(6, 4);

            if (int.TryParse(yearPart, out int year) && year == currentYear)
            {
                Console.WriteLine(date);
            }
        }
    }
}






/*using System;

class Program
{
    // Функция для вычисления значения Y(x)
    static double CalculateY(double x)
    {
        return (1 - (x * x / 4)) * Math.Cos(x) - (x / 2) * Math.Sin(x);
    }

    static void Main(string[] args)
    {
        // Ввод исходных значений
        Console.Write("Введите a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Введите b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Введите шаг h: ");
        double h = double.Parse(Console.ReadLine());

        Console.Write("Введите количество шагов n: ");
        int n = int.Parse(Console.ReadLine());

        // Заголовок таблицы
        Console.WriteLine("\nТаблица значений Y(x):");
        Console.WriteLine("x\t\tY(x)");
        Console.WriteLine("----------------------------");

        // Цикл для вычисления Y(x) для каждого x от a до b с шагом h
        for (double x = a; x <= b; x += h)
        {
            double y = CalculateY(x); // Вычисляем значение Y(x)
            Console.WriteLine($"{x:F2}\t\t{y:F4}");
        }
    }
}
*/

/*using System;

class Program
{
    // Рекурсивная функция для вычисления y = x^n
    static double Power(double x, int n)
    {
        // Базовый случай: любое число в степени 0 равно 1
        if (n == 0)
            return 1;

        // Если степень четная
        if (n % 2 == 0)
        {
            double halfPower = Power(x, n / 2);
            return halfPower * halfPower;
        }
        else // Если степень нечетная
        {
            return x * Power(x, n - 1);
        }
    }

    static void Main(string[] args)
    {
        // Ввод исходных значений x и n
        Console.Write("Введите число x: ");
        double x = double.Parse(Console.ReadLine());

        Console.Write("Введите степень n: ");
        int n = int.Parse(Console.ReadLine());

        // Вычисляем y = x^n с помощью рекурсивной функции
        double result = Power(x, n);

        // Вывод результата
        Console.WriteLine($"{x}^{n} = {result}");
    }
}
*/

/*using System;

class Program
{
    // Функция для определения максимального из двух чисел
    static double MaxOfTwo(double a, double b)
    {
        return (a > b) ? a : b;
    }

    static void Main(string[] args)
    {
        // Ввод 8 различных чисел
        double[] numbers = new double[8];
        Console.WriteLine("Введите 8 различных чисел:");

        for (int i = 0; i < 8; i++)
        {
            Console.Write($"Число {i + 1}: ");
            numbers[i] = double.Parse(Console.ReadLine());
        }

        // Поиск максимального числа среди всех 8 чисел
        double max = numbers[0]; // Инициализируем максимальное первое число
        for (int i = 1; i < 8; i++)
        {
            max = MaxOfTwo(max, numbers[i]); // Сравниваем текущее максимальное с каждым следующим числом
        }

        // Вывод максимального числа
        Console.WriteLine($"\nМаксимальное число: {max}");
    }
}
*/

/*using System;

class Program
{
    // Функция для сортировки массива и исключения отрицательных чисел
    static double[] SortArrayExcludingNegatives(double[] arr)
    {
        // Используем LINQ для фильтрации только положительных чисел и нуля
        double[] filteredArray = arr.Where(x => x >= 0).ToArray();

        // Сортируем оставшиеся положительные числа
        Array.Sort(filteredArray);

        return filteredArray;
    }

    static void Main(string[] args)
    {
        // Ввод исходного массива
        Console.WriteLine("Введите количество элементов массива:");
        int n = int.Parse(Console.ReadLine());
        double[] numbers = new double[n];

        Console.WriteLine("Введите элементы массива:");

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Число {i + 1}: ");
            numbers[i] = double.Parse(Console.ReadLine());
        }

        // Сортируем массив, исключив отрицательные числа
        double[] sortedNumbers = SortArrayExcludingNegatives(numbers);

        // Вывод результата
        Console.WriteLine("\nОтсортированный массив (без отрицательных чисел):");
        foreach (double num in sortedNumbers)
        {
            Console.Write($"{num} ");
        }
        Console.WriteLine();
    }
}
*/

using System;

class Program
{
    // Основная функция для нахождения минимального элемента в массиве X
    static double Min(double[] X)
    {
        return Minl(X, 0); // Запуск рекурсии с 0-го элемента
    }

    // Рекурсивная вспомогательная функция для нахождения минимума начиная с k-го элемента
    static double Minl(double[] X, int k)
    {
        // Базовый случай: если мы находимся на последнем элементе массива, возвращаем его
        if (k == X.Length - 1)
        {
            return X[k];
        }

        // Рекурсивный вызов для нахождения минимума среди остальных элементов
        double minOfRest = Minl(X, k + 1);

        // Возвращаем минимум между текущим элементом и минимумом среди оставшихся
        return (X[k] < minOfRest) ? X[k] : minOfRest;
    }

    static void Main(string[] args)
    {
        // Ввод исходного массива
        Console.WriteLine("Введите количество элементов массива:");
        int n = int.Parse(Console.ReadLine());
        double[] numbers = new double[n];

        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Число {i + 1}: ");
            numbers[i] = double.Parse(Console.ReadLine());
        }

        // Нахождение минимального элемента
        double minElement = Min(numbers);

        // Вывод результата
        Console.WriteLine($"\nМинимальный элемент массива: {minElement}");
    }
}

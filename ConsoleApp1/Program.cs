using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Примерный массив
        double[] numbers = { -5.4, 2.3, 7.8, -1.2, 0, 3.5, -9.1, 4.4 };
        double A = -2.0;
        double B = 5.0;

        // 1. Количество элементов массива, лежащих в диапазоне от A до B
        int countInRange = numbers.Count(x => x >= A && x <= B);
        Console.WriteLine($"Количество элементов в диапазоне от {A} до {B}: {countInRange}");

        // 2. Сумма элементов массива, расположенных после максимального элемента
        double max = numbers.Max();
        int maxIndex = Array.IndexOf(numbers, max);
        double sumAfterMax = numbers.Skip(maxIndex + 1).Sum();
        Console.WriteLine($"Сумма элементов после максимального ({max}): {sumAfterMax}");

        // 3. Упорядочить элементы массива по убыванию модулей
        var sortedByAbsDesc = numbers.OrderByDescending(x => Math.Abs(x)).ToArray();
        Console.WriteLine("Массив по убыванию модулей:");
        Console.WriteLine(string.Join(", ", sortedByAbsDesc));
    }
}

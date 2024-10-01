using System;

class Program
{
    static void Main()
    {
        double[] arr = { 3.5, -2.1, 7.3, -4.0, 1.2, 5.5, -6.3, 8.0, 0.0, -1.5 };
        double A = 0;
        double B = 5;

        // 1. Количество элементов в диапазоне от A до B
        int countInRange = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= A && arr[i] <= B)
                countInRange++;
        }
        Console.WriteLine($"Количество элементов в диапазоне [{A}, {B}]: {countInRange}");

        // 2. Сумма элементов после максимального элемента
        double max = arr[0];
        int maxIndex = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                maxIndex = i;
            }
        }

        double sumAfterMax = 0;
        for (int i = maxIndex + 1; i < arr.Length; i++)
        {
            sumAfterMax += arr[i];
        }
        Console.WriteLine($"Сумма элементов после максимального: {sumAfterMax}");

        // 3. Упорядочить элементы по убыванию модулей
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (Math.Abs(arr[i]) < Math.Abs(arr[j]))
                {
                    double temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }

        Console.WriteLine("Упорядоченный массив по убыванию модулей: " + string.Join(", ", arr));
    }
}
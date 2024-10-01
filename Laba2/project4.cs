using System;

class Program
{
    static void Main()
    {
        // 1. Вычисление суммы геометрической прогрессии
        int sumGeo = 0;
        for (int i = 0; i <= 10; i++)
        {
            sumGeo += (int)Math.Pow(2, i);
        }
        Console.WriteLine("Сумма геометрической прогрессии: " + sumGeo);

        // 2. Вычисление произведения сумм последовательностей
        long productOfSums = 1;
        for (int i = 1; i <= 10; i++)
        {
            int sum = (i * (i + 1)) / 2;
            productOfSums *= sum;
        }
        Console.WriteLine("Произведение сумм последовательностей: " + productOfSums);
    }
}
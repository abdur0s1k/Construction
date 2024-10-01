using System;

class Program
{
    static void Main()
    {
        double xStart = -2;    // Начальное значение x
        double xEnd = 2;       // Конечное значение x
        double step = 0.5;     // Шаг изменения x
        double epsilon = 1e-6; // Точность вычислений
        int maxTerms = 100;    // Максимальное количество членов ряда

        Console.WriteLine("x\tTerms\tApproximation");

        for (double x = xStart; x <= xEnd; x += step)
        {
            double result = 0;      // Текущая сумма ряда
            double term = 1;        // Начальный член ряда
            long factorial = 1;     // Начальный факториал (0! = 1)

            int n = 0;

            for (n = 0; n < maxTerms; n++)
            {

                result += term;


                if (Math.Abs(term) < epsilon)
                    break;

                factorial *= (2 * n + 1) * (2 * n + 2);
                term = Math.Pow(-1, n + 1) * Math.Pow(x, 2 * (n + 1)) / factorial;
            }

            Console.WriteLine($"{x:F2}\t{n + 1}\t{result:F6}");
        }
    }
}
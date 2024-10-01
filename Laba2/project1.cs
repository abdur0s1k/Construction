using System;

class Program
{
    static void Main()
    {
        double dx = 0.5; // Шаг dx
        double xStart = -5; // Начальное значение x
        double xEnd = 9; // Конечное значение x
        double R = 3; //Радиус 

        Console.WriteLine("Таблица значений функции:");
        Console.WriteLine("----------------------------");
        Console.WriteLine("|    x    |    y    |");
        Console.WriteLine("----------------------------");

        for (double x = xStart; x <= xEnd; x += dx)
        {
            double y;

            if (x >= -3 && x <= 0)
            {
                y = Math.Sqrt(R * R - x * x);
            }
            else if (x >= -5 && x < -3)
            {
                y = x + 3;
            }
            else if (x > 0 && x <= 6)
            {
                y = (-0.5 * x) - R + 6;
            }
            else
            {
                y = x - 6;
            }
            Console.WriteLine($"| {x,6:F2} | {y,6:F2} |");
        }

        Console.WriteLine("----------------------------");
    }
}
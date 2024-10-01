using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите значение R: ");
        double R = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите значение x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        double y;

        if (x >= -3 && x <= 0)
        {
            y = Math.Sqrt(R * R - x * x);
        }
        else if (x >= -5 && x < -3)
        {
            y = x + 6;
        }
        else if (x > 0 && x <= 6)
        {
            y = (-1 * x) - R + 6;
        }
        else if (x > 6)
        {
            y = x - 6;
        }
        else
        {
            Console.WriteLine("Значение x вне допустимого диапазона.");
            return;
        }

        Console.WriteLine("Значение функции: y = " + y);
    }
}






using System;

class Program
{
    static void Main()
    {

        Console.Write("Введите координату x: ");
        double x = double.Parse(Console.ReadLine());

        Console.Write("Введите координату y: ");
        double y = double.Parse(Console.ReadLine());


        if ((y == x && x >= 0 && x <= 70) || (x == 70 && y >= 0 && y <= 70) || (y == 0 && x >= 0 && x <= 70))
        {
            Console.WriteLine("На границе");
        }

        else if (x >= 0 && x <= 70 && y >= 0 && y <= x)
        {
            Console.WriteLine("Да");
        }

        else
        {
            Console.WriteLine("Нет");
        }
    }
}
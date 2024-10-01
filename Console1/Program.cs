using System;

class Program
{
    static void Main()
    {

        Console.Write("Введите трёхзначное число: ");
        int number = int.Parse(Console.ReadLine());

        int first = number / 100;
        int second = (number / 10) % 10;

        if (first > second)
        {
            Console.WriteLine($"Первая цифра ({first}) больше второй ({second}).");
        }
        else if (second > first)
        {
            Console.WriteLine($"Вторая цифра ({second}) больше первой ({first}).");
        }
        else
        {
            Console.WriteLine($"Первая и вторая цифры равны ({first}).");
        }
    }
}
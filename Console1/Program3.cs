using System;

class Program
{
    static void Main()
    {

        Console.Write("Введите количество баллов (от 0 до 100): ");
        int score = int.Parse(Console.ReadLine());

        if (score >= 90 && score <= 100)
        {
            Console.WriteLine("Отлично");
        }
        else if (score >= 70 && score <= 89)
        {
            Console.WriteLine("Хорошо");
        }
        else if (score >= 50 && score <= 69)
        {
            Console.WriteLine("Удовлетворительно");
        }
        else if (score < 50 && score >= 0)
        {
            Console.WriteLine("Неудовлетворительно");
        }
        else
        {
            Console.WriteLine("Некорректный ввод");
        }
    }
}
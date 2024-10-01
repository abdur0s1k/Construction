using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите значение A: ");
        int A = int.Parse(Console.ReadLine());

        Console.Write("Введите значение B: ");
        int B = int.Parse(Console.ReadLine());

        int i = A;

        // Цикл while
        while (i <= B)
        {
            if (i > 0)
            {
                Console.WriteLine(i);
            }
            i++;
        }



        // Цикл do while
        do
        {
            if (i > 0)
            {
                Console.WriteLine(i);
            }
            i++;
        } while (i <= B);

        // Цикл for
        for (int i = A; i <= B; i++)
        {
            if (i > 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}
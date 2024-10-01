using System;

class Program
{
    static void Main()
    {
        for (int i = 5; i > 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }
    }
}

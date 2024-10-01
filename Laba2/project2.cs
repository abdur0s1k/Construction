using System;

class Program
{
    static void Main()
    {
        const double R1 = 5.0;
        const double R2 = 3.0;

        for (int i = 0; i < 10; i++) // 10 выстрелов
        {
            Console.WriteLine("Введите координаты выстрела (x y):");
            double x = Convert.ToDouble(Console.ReadLine());
            double y = Convert.ToDouble(Console.ReadLine());

            double distance = Math.Sqrt(x * x + y * y);

            // Проверка для верхнего левого квадранта (расстояние <= R2)
            if (x <= 0 && y >= 0 && distance <= R2)
            {
                Console.WriteLine("Попадание в мишень.");
            }
            // Проверка для нижнего правого квадранта (R2 <= расстояние <= R1)
            else if (x >= 0 && y <= 0 && distance >= R2 && distance <= R1)
            {
                Console.WriteLine("Попадание в мишень.");
            }
            else
            {
                Console.WriteLine("Мимо мишени.");
            }
        }
    }
}

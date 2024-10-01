using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Выберите задание:");
            Console.WriteLine("1. Таблица значений функции");
            Console.WriteLine("2. Проверка попадания в мишень");
            Console.WriteLine("3. Вычисление суммы ряда");
            Console.WriteLine("4. Сумма геометрической прогрессии и произведение сумм последовательностей");
            Console.WriteLine("5. Вычисление значений функции y по диапазону x");
            Console.WriteLine("0. Выход");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                case 5:
                    Task5();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте снова.");
                    break;
            }
        }
    }

    static void Task1()
    {
        double dx = 0.5;
        double xStart = -5;
        double xEnd = 9;
        double R = 3;

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

    static void Task2()
    {
        const double R1 = 5.0;
        const double R2 = 3.0;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Введите координаты выстрела (x y):");
            double x = Convert.ToDouble(Console.ReadLine());
            double y = Convert.ToDouble(Console.ReadLine());

            double distance = Math.Sqrt(x * x + y * y);

            if (x <= 0 && y >= 0 && distance <= R2)
            {
                Console.WriteLine("Попадание в мишень.");
            }
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

    static void Task3()
    {
        double xStart = -2;
        double xEnd = 2;
        double step = 0.5;
        double epsilon = 1e-6;
        int maxTerms = 100;

        Console.WriteLine("x\tTerms\tApproximation");

        for (double x = xStart; x <= xEnd; x += step)
        {
            double result = 0;
            double term = 1;
            long factorial = 1;

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

    static void Task4()
    {
        int sumGeo = 0;
        for (int i = 0; i <= 10; i++)
        {
            sumGeo += (int)Math.Pow(2, i);
        }
        Console.WriteLine("Сумма геометрической прогрессии: " + sumGeo);

        long productOfSums = 1;
        for (int i = 1; i <= 10; i++)
        {
            int sum = (i * (i + 1)) / 2;
            productOfSums *= sum;
        }
        Console.WriteLine("Произведение сумм последовательностей: " + productOfSums);
    }

    static void Task5()
    {
        double pi = -1 * Math.PI;
        double pi2 = Math.PI / 2;

        for (double x = pi; x < pi2; x += 0.2)
        {
            double y;

            if (x > 2.5)
            {
                y = x + 1;
                Console.WriteLine($"y = {y:F4}");
            }
            else if (0 <= x && x <= 2.5)
            {
                y = 1 - Math.Pow(x, 5);
                Console.WriteLine($"y = {y:F4}");
            }
            else if (x < 0)
            {
                y = x * Math.Log(Math.Abs(Math.Cos(x)));
                Console.WriteLine($"y = {y:F4}");
            }
        }
    }
}

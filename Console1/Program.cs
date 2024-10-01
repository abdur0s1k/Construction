using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите задание (1-5):");
        Console.WriteLine("1. Сравнить первую и вторую цифры трёхзначного числа.");
        Console.WriteLine("2. Проверить точку на принадлежность области.");
        Console.WriteLine("3. Оценка по количеству баллов.");
        Console.WriteLine("4. Вывод положительных чисел от A до B.");
        Console.WriteLine("5. Вывести треугольник.");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                CompareDigits();
                break;
            case 2:
                CheckPoint();
                break;
            case 3:
                GradeScore();
                break;
            case 4:
                PrintPositiveNumbers();
                break;
            case 5:
                PrintTriangle();
                break;
            default:
                Console.WriteLine("Некорректный выбор.");
                break;
        }
    }

    // Задание 1: Сравнение первой и второй цифры числа
    static void CompareDigits()
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

    // Задание 2: Проверка точки на принадлежность области
    static void CheckPoint()
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

    // Задание 3: Оценка по количеству баллов
    static void GradeScore()
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

    // Задание 4: Вывод положительных чисел от A до B
    static void PrintPositiveNumbers()
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

    // Задание 5: Вывести треугольник
    static void PrintTriangle()
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

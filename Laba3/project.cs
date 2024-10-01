using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите задание (1 - Работа с массивом, 2 - Сдвиг матрицы):");
        int taskChoice = int.Parse(Console.ReadLine());

        switch (taskChoice)
        {
            case 1:
                WorkWithArray();
                break;
            case 2:
                ShiftMatrix();
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }
    }

    // Функция для задания 1 (Работа с массивом)
    static void WorkWithArray()
    {
        double[] arr = { 3.5, -2.1, 7.3, -4.0, 1.2, 5.5, -6.3, 8.0, 0.0, -1.5 };
        double A = 0;
        double B = 5;

        // 1. Количество элементов в диапазоне от A до B
        int countInRange = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= A && arr[i] <= B)
                countInRange++;
        }
        Console.WriteLine($"Количество элементов в диапазоне [{A}, {B}]: {countInRange}");

        // 2. Сумма элементов после максимального элемента
        double max = arr[0];
        int maxIndex = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                maxIndex = i;
            }
        }

        double sumAfterMax = 0;
        for (int i = maxIndex + 1; i < arr.Length; i++)
        {
            sumAfterMax += arr[i];
        }
        Console.WriteLine($"Сумма элементов после максимального: {sumAfterMax}");

        // 3. Упорядочить элементы по убыванию модулей
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (Math.Abs(arr[i]) < Math.Abs(arr[j]))
                {
                    double temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }

        Console.WriteLine("Упорядоченный массив по убыванию модулей: " + string.Join(", ", arr));
    }

    // Функция для задания 2 (Сдвиг матрицы)
    static void ShiftMatrix()
    {
        int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        Console.WriteLine("Введите количество сдвигов:");
        int p = int.Parse(Console.ReadLine());

        Console.WriteLine("Выберите направление сдвига (1 - вправо, 2 - вниз):");
        int direction = int.Parse(Console.ReadLine());

        bool shiftRight = direction == 1;

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (shiftRight)
        {
            p = p % cols; // Учитываем количество столбцов
            if (p != 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    int[] temp = new int[cols];
                    for (int j = 0; j < cols; j++)
                    {
                        temp[(j + p) % cols] = matrix[i, j];
                    }
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = temp[j];
                    }
                }
            }
        }
        else
        {
            p = p % rows; // Учитываем количество строк
            if (p != 0)
            {
                for (int j = 0; j < cols; j++)
                {
                    int[] temp = new int[rows];
                    for (int i = 0; i < rows; i++)
                    {
                        temp[(i + p) % rows] = matrix[i, j];
                    }
                    for (int i = 0; i < rows; i++)
                    {
                        matrix[i, j] = temp[i];
                    }
                }
            }
        }

        // Печать матрицы
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

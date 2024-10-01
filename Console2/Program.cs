/*using System;

class Program
{
    static void Main()
    {
        // Инициализация массива из 15 элементов
        int[] array = new int[15];

        // Ввод массива
        Console.WriteLine("Введите 15 целых чисел:");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        // Поиск максимального и минимального элементов
        int max = array[0];
        int min = array[0];

        foreach (int number in array)
        {
            if (number > max)
            {
                max = number;
            }
            if (number < min)
            {
                min = number;
            }
        }

        // Вычисление суммы и разности
        int sum = max + min;
        int difference = max - min;

        // Вывод результатов
        Console.WriteLine("Максимальный элемент: " + max);
        Console.WriteLine("Минимальный элемент: " + min);
        Console.WriteLine("Сумма максимального и минимального элементов: " + sum);
        Console.WriteLine("Разность максимального и минимального элементов: " + difference);
    }
}

*/

/*using System;

class Program
{
    static void Main()
    {
        // Инициализация массива из 10 элементов
        int[] array = new int[10];
        int[] counts = new int[10];  // Массив для подсчета количества вхождений каждого элемента

        // Ввод массива
        Console.WriteLine("Введите 10 целых чисел:");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        // Подсчет количества вхождений каждого элемента
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length; j++)
            {
                if (array[i] == array[j])
                {
                    counts[i]++;
                }
            }
        }

        // Создание нового массива с удалением элементов, встречающихся более двух раз
        Console.WriteLine("Массив после удаления элементов, которые встречаются более двух раз:");
        for (int i = 0; i < array.Length; i++)
        {
            if (counts[i] <= 2)
            {
                Console.Write(array[i] + " ");
            }
        }

        Console.WriteLine();
    }
}
*/

/*using System;

class Program
{
    static void Main()
    {
        // Ввод размерности массива
        Console.WriteLine("Введите количество строк (n): ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите количество столбцов (m): ");
        int m = int.Parse(Console.ReadLine());

        // Инициализация двумерного массива
        int[,] array = new int[n, m];

        // Ввод элементов массива
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"Элемент [{i}, {j}]: ");
                array[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Поиск наибольшего элемента в каждом столбце
        Console.WriteLine("Наибольшие элементы в каждом столбце:");
        for (int j = 0; j < m; j++)
        {
            int max = array[0, j];  // Изначально берем первый элемент столбца
            for (int i = 1; i < n; i++)
            {
                if (array[i, j] > max)
                {
                    max = array[i, j];  // Обновляем максимальное значение для столбца
                }
            }
            Console.WriteLine($"Столбец {j + 1}: {max}");
        }
    }
}
*/

/*using System;

class Program
{
    static void Main()
    {
        // Ввод размерности матрицы
        Console.WriteLine("Введите количество строк (M): ");
        int m = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите количество столбцов (N): ");
        int n = int.Parse(Console.ReadLine());

        // Инициализация двумерной матрицы
        int[,] matrix = new int[m, n];

        // Ввод элементов матрицы
        Console.WriteLine("Введите элементы матрицы:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"Элемент [{i}, {j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Инициализация одномерного массива для элементов, лежащих в интервале [1, 10]
        int[] filteredArray = new int[m * n];  // Максимально возможный размер одномерного массива
        int index = 0;
        long product = 1;
        bool hasElementsInRange = false;

        // Поиск элементов в интервале [1, 10] и формирование одномерного массива
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] >= 1 && matrix[i, j] <= 10)
                {
                    filteredArray[index++] = matrix[i, j];
                    product *= matrix[i, j];  // Вычисление произведения элементов
                    hasElementsInRange = true;
                }
            }
        }

        // Вывод одномерного массива и произведения
        if (hasElementsInRange)
        {
            Console.WriteLine("Элементы в интервале [1, 10]:");
            for (int i = 0; i < index; i++)
            {
                Console.Write(filteredArray[i] + " ");
            }
            Console.WriteLine("\nПроизведение элементов: " + product);
        }
        else
        {
            Console.WriteLine("Нет элементов, лежащих в интервале [1, 10].");
        }
    }
}
*/
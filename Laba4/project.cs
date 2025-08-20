/*using System;

class Program
{
    static void Main()
    {
        double[] arr = { 3.5, -2.1, 7.3, -4.0, 1.2, 5.5, -6.3, 8.0, 0.0, -1.5 };
        double A = 0;
        double B = 5;

        // 1. Количество элементов в диапазоне от A до B
        int countInRange = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= A && arr[i] <= B)
            {
                countInRange++;
            }
        }
        Console.WriteLine($"Количество элементов в диапазоне [{A}, {B}]: {countInRange}");

        // 2. Сумма элементов после максимального элемента
        double max = arr[0];
        int maxIndex = 0;

        // Находим максимальный элемент и его индекс
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                maxIndex = i;
            }
        }

        // Вычисляем сумму элементов после максимального
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
                if (Math.Abs(arr[j]) > Math.Abs(arr[i]))
                {
                    // Меняем элементы местами
                    double temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }

        Console.WriteLine("Упорядоченный массив по убыванию модулей: " + string.Join(", ", arr));
    }
}*/
/*using System;

class Program
{
    static void Main()
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

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (direction == 1) // Сдвиг вправо
        {
            p %= cols;
            for (int i = 0; i < rows; i++)
            {
                int[] row = new int[cols];

                // Копируем строку вручную
                for (int j = 0; j < cols; j++)
                {
                    row[j] = matrix[i, j];
                }

                // Сдвиг вправо с использованием System.Array
                int[] temp = new int[cols];
                Array.Copy(row, cols - p, temp, 0, p);
                Array.Copy(row, 0, temp, p, cols - p);

                // Возвращаем сдвинутую строку в матрицу
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = temp[j];
                }
            }
        }
        else if (direction == 2) // Сдвиг вниз
        {
            p %= rows;
            for (int j = 0; j < cols; j++)
            {
                int[] column = new int[rows];

                // Копируем столбец вручную
                for (int i = 0; i < rows; i++)
                {
                    column[i] = matrix[i, j];
                }

                // Сдвиг вниз с использованием System.Array
                int[] temp = new int[rows];
                Array.Copy(column, rows - p, temp, 0, p);
                Array.Copy(column, 0, temp, p, rows - p);

                // Возвращаем сдвинутый столбец в матрицу
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, j] = temp[i];
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
*/
/*using System;

class Program
{
    static void Main()
    {
        // Инициализация массива на 11 элементов
        int[] array = new int[11];
        Console.WriteLine("Введите 11 целых чисел:");

        // Ввод массива с клавиатуры
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        // Переменная для хранения суммы нечетных отрицательных элементов
        int sum = 0;

        // Вычисление суммы нечетных отрицательных элементов
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0 && array[i] % 2 != 0) // Проверка на отрицательные нечетные числа
            {
                sum += array[i];
            }
        }

        // Вывод суммы для проверки
        Console.WriteLine($"Сумма нечетных отрицательных элементов: {sum}");

        // Замена элементов, кратных трем, на сумму
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 3 == 0)
            {
                array[i] = sum; // Замена элемента на сумму
            }
        }

        // Вывод измененного массива
        Console.WriteLine("Измененный массив:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}
*/
/*using System;

class Program
{
    static void Main()
    {
        // Определяем размер массива
        Console.Write("Введите количество строк (n): ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введите количество столбцов (m): ");
        int m = int.Parse(Console.ReadLine());

        // Инициализируем двумерный массив
        int[,] array = new int[n, m];

        // Вводим элементы массива с клавиатуры
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"array[{i},{j}]: ");
                array[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Находим наибольший элемент в каждом столбце
        int[] maxInColumns = new int[m]; // Массив для хранения наибольших элементов

        for (int j = 0; j < m; j++)
        {
            maxInColumns[j] = array[0, j]; // Инициализируем максимальное значение первым элементом столбца

            for (int i = 1; i < n; i++)
            {
                // Сравниваем и находим максимальное значение в текущем столбце
                if (array[i, j] > maxInColumns[j])
                {
                    maxInColumns[j] = array[i, j];
                }
            }
        }

        // Выводим наибольшие элементы в каждом столбце
        Console.WriteLine("Наибольшие элементы в каждом столбце:");
        for (int j = 0; j < m; j++)
        {
            Console.WriteLine($"Столбец {j + 1}: {maxInColumns[j]}");
        }
    }
}
*/
/*using System;

class Program
{
    static void Main()
    {
        // Ввод двоичного числа как строки
        Console.Write("Введите двоичное число: ");
        string binaryInput = Console.ReadLine();

        // Преобразуем двоичное число в массив символов
        char[] binaryArray = binaryInput.ToCharArray();
        int length = binaryArray.Length;

        // Выполняем циклический сдвиг влево на 2 позиции
        char[] shiftedArray = new char[length]; // создаем новый массив для хранения сдвинутых элементов

        for (int i = 0; i < length; i++)
        {
            // Элемент из индекса i перемещаем на (i - 2) % length, для циклического сдвига
            shiftedArray[i] = binaryArray[(i + 2) % length];
        }

        // Преобразуем массив обратно в строку
        string shiftedBinary = new string(shiftedArray);

        // Конвертируем исходное и сдвинутое двоичное число в десятичное
        int originalDecimal = Convert.ToInt32(binaryInput, 2);
        int shiftedDecimal = Convert.ToInt32(shiftedBinary, 2);

        // Вычисляем разность
        int difference = originalDecimal - shiftedDecimal;

        // Вывод результатов
        Console.WriteLine($"Исходное двоичное число: {binaryInput} (в десятичной системе: {originalDecimal})");
        Console.WriteLine($"Сдвинутое двоичное число: {shiftedBinary} (в десятичной системе: {shiftedDecimal})");
        Console.WriteLine($"Разность: {difference}");
    }
}
*/

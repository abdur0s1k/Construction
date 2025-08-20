/*using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] array = { -5, -2, 3, 7, -1, 4, 8, -9, 6, 0 };

        // Находим индекс первого положительного элемента
        int firstPositiveIndex = Array.FindIndex(array, x => x > 0);

        if (firstPositiveIndex == -1)
        {
            Console.WriteLine("Положительный элемент не найден.");
        }
        else
        {
            // Суммируем элементы после первого положительного
            int sum = array.Skip(firstPositiveIndex + 1).Sum();

            Console.WriteLine($"Сумма элементов после первого положительного: {sum}");
        }
    }
}*/


using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int n = 10;
        double[] array = new double[n];

        // Заполнение массива случайными числами и округление до двух знаков
        for (int i = 0; i < n; i++)
        {
            array[i] = Math.Round(rand.NextDouble() * 100, 2);
        }

        // Сортировка массива
        Array.Sort(array);

        Console.WriteLine("Исходный отсортированный массив:");
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        Console.Write("Введите число для вставки: ");
        double b = Convert.ToDouble(Console.ReadLine());

        // Создание нового массива с одним дополнительным элементом
        double[] newArray = new double[array.Length + 1];

        // Находим индекс для вставки с помощью бинарного поиска
        int insertIndex = Array.BinarySearch(array, b);
        if (insertIndex < 0)
        {
            insertIndex = ~insertIndex; // Получаем индекс, где нужно вставить элемент
        }

        // Копируем элементы до места вставки
        Array.Copy(array, newArray, insertIndex);

        // Вставляем новый элемент
        newArray[insertIndex] = b;

        // Копируем оставшиеся элементы
        Array.Copy(array, insertIndex, newArray, insertIndex + 1, array.Length - insertIndex);

        // Вывод нового отсортированного массива
        Console.WriteLine("Новый отсортированный массив:");
        foreach (var item in newArray)
        {
            Console.Write(item + " ");
        }
    }
}

/*using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int n = 5;
        int[,] array = new int[n, n];

        // Заполнение массива случайными числами от 1 до 100
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                array[i, j] = rand.Next(1, 101);
            }
        }

        Console.WriteLine("Исходный массив:");
        // Используем методы класса Array для вывода массива
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(array.GetValue(i, j) + " ");
            }
            Console.WriteLine();
        }

        Console.Write("Введите k1 (начальный индекс): ");
        int k1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите k2 (конечный индекс): ");
        int k2 = Convert.ToInt32(Console.ReadLine());

        int[] sumArray = new int[n];

        // Вычисляем сумму элементов в диапазоне для каждой строки
        for (int i = 0; i < n; i++)
        {
            int sum = 0; // Сумма для текущей строки
            for (int j = k1; j <= k2; j++)
            {
                sum += (int)array.GetValue(i, j); // Используем GetValue для доступа к элементам
            }
            sumArray[i] = sum; // Записываем сумму в массив
        }

        Console.WriteLine("Массив с суммами элементов в диапазоне от k1 до k2:");
        // Выводим массив сумм
        for (int i = 0; i < n; i++)
        {
            Console.Write(sumArray[i] + " ");
        }
    }
}
*/

/*using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество подмассивов: ");
        int n = Convert.ToInt32(Console.ReadLine());

        // Создаем массив для хранения подмассивов
        Array jaggedArray = Array.CreateInstance(typeof(Array), n);

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите количество элементов в подмассиве {i + 1}: ");
            int size = Convert.ToInt32(Console.ReadLine());

            // Создаем подмассив и добавляем его в основной массив
            Array subArray = Array.CreateInstance(typeof(int), size);
            Console.WriteLine($"Введите {size} элементов для подмассива {i + 1}:");
            for (int j = 0; j < size; j++)
            {
                int element = Convert.ToInt32(Console.ReadLine());
                subArray.SetValue(element, j); // Устанавливаем значение элемента
            }

            jaggedArray.SetValue(subArray, i); // Устанавливаем подмассив
        }

        // Обрабатываем массив
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            Array subArray = (Array)jaggedArray.GetValue(i); // Получаем подмассив
            bool containsNegative = false;

            // Проверяем наличие отрицательных элементов
            for (int j = 0; j < subArray.Length; j++)
            {
                int element = (int)subArray.GetValue(j); // Получаем значение элемента
                if (element < 0)
                {
                    containsNegative = true;
                    break;
                }
            }

            // Если есть отрицательный элемент, вычисляем произведение
            if (containsNegative)
            {
                int product = 1;
                for (int j = 0; j < subArray.Length; j++)
                {
                    product *= (int)subArray.GetValue(j); // Получаем значение элемента
                }
                Console.WriteLine($"Произведение элементов подмассива {i + 1}: {product}");
            }
        }
    }
}
*/

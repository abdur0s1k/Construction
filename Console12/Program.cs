/*using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите сторону квадрата (a): ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException("Сторона квадрата не может быть пустой.");
            }

            if (!double.TryParse(input, out double side))
            {
                throw new FormatException("Некорректный формат ввода. Введите число.");
            }

            if (side <= 0)
            {
                throw new ArgumentOutOfRangeException("Сторона квадрата должна быть положительным числом.");
            }

            double inscribedRadius = side / 2;
            double circumscribedRadius = side * Math.Sqrt(2) / 2;

            Console.WriteLine($"Радиус вписанной окружности: {inscribedRadius:F2}");
            Console.WriteLine($"Радиус описанной окружности: {circumscribedRadius:F2}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
        }
    }
}
*/

/*using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите размер матрицы (N): ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException("Размер матрицы не может быть пустым.");
            }

            if (!int.TryParse(input, out int n))
            {
                throw new FormatException("Некорректный формат ввода. Введите целое число.");
            }

            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException("Размер матрицы должен быть положительным числом.");
            }

            int[,] matrix = new int[n, n];
            Console.WriteLine("Введите элементы матрицы:");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {n} элементов {i + 1}-й строки через пробел:");
                string rowInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(rowInput))
                {
                    throw new ArgumentNullException("Строка не может быть пустой.");
                }

                int[] rowElements = rowInput.Split(' ').Select(x =>
                {
                    if (!int.TryParse(x, out int value))
                    {
                        throw new FormatException("Некорректный формат элемента строки. Введите целые числа.");
                    }
                    return value;
                }).ToArray();

                if (rowElements.Length != n)
                {
                    throw new ArgumentException("Количество элементов в строке должно совпадать с размером матрицы.");
                }

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowElements[j];
                }
            }

            int maxElement = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                    }
                }
            }

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix.Cast<int>().Skip(i * n).Take(n).Contains(maxElement))
                {
                    sum += matrix.Cast<int>().Skip(i * n).Take(n).Sum();
                }
            }

            Console.WriteLine($"Наибольший элемент матрицы: {maxElement}");
            Console.WriteLine($"Сумма элементов строк, содержащих наибольший элемент: {sum}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
        }
    }
}

*/

/*using System;
using System.Collections.Generic;

class DiscountCardException : Exception
{
    public DiscountCardException(string message) : base(message) { }
}

class Program
{
    class Customer
    {
        private string cardNumber;
        private string fullName;
        private double discount;

        public string GetCardNumber()
        {
            return cardNumber;
        }

        public void SetCardNumber(string value)
        {
            cardNumber = value;
        }

        public string GetFullName()
        {
            return fullName;
        }

        public void SetFullName(string value)
        {
            fullName = value;
        }

        public double GetDiscount()
        {
            return discount;
        }

        public void SetDiscount(double value)
        {
            discount = value;
        }

        public override string ToString()
        {
            return $"Номер карты: {cardNumber}, ФИО: {fullName}, Скидка: {discount}%";
        }
    }

    static void Main()
    {
        try
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer { 
                    cardNumber = "12345", 
                    fullName = "Иванов Иван Иванович", 
                    discount = 10 
                },
                new Customer { 
                    cardNumber = "23456", 
                    fullName = "Петров Петр Петрович", 
                    discount = 5 
                },
                new Customer { 
                    cardNumber = "34567", 
                    fullName = "Сидоров Сидор Сидорович", 
                    discount = 10 
                },
                new Customer { 
                    cardNumber = "45678", 
                    fullName = "Кузнецова Мария Ивановна", 
                    discount = 15 
                }
            };

            Console.WriteLine("Введите минимальную скидку для фильтрации (например, 10): ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException("Ввод не может быть пустым.");
            }

            if (!double.TryParse(input, out double filterDiscount))
            {
                throw new FormatException("Некорректный формат ввода. Введите число.");
            }

            if (filterDiscount < 0)
            {
                throw new DiscountCardException("Скидка не может быть отрицательной.");
            }

            List<Customer> filteredCustomers = customers.FindAll(c => c.GetDiscount() == filterDiscount);

            if (filteredCustomers.Count == 0)
            {
                throw new DiscountCardException("Нет покупателей с указанной скидкой.");
            }

            Console.WriteLine("Покупатели с указанной скидкой:");
            foreach (var customer in filteredCustomers)
            {
                Console.WriteLine(customer);
            }
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (DiscountCardException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
        }
    }
}
*/

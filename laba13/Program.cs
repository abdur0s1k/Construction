/*using System;

// Класс X с реализацией ICloneable
public class X : ICloneable
{
    protected int x1;
    protected int x2;

    public X(int x1, int x2)
    {
        this.x1 = x1;
        this.x2 = x2;
    }

    public virtual object Clone()
    {
        return new X(x1, x2);
    }

    public void Input(int x1, int x2)
    {
        this.x1 = x1;
        this.x2 = x2;
    }

    public void Output()
    {
        Console.WriteLine("X1: {0}, X2: {1}", x1, x2);
    }
}

// Класс Y, наследуемый от X
public class Y : X
{
    private int y;

    public Y(int x1, int x2, int y) : base(x1, x2)
    {
        this.y = y;
    }

    public override object Clone()
    {
        return new Y(x1, x2, y); // Создание и возврат экземпляра Y
    }

    public void Input(int x1, int x2, int y)
    {
        base.Input(x1, x2);
        this.y = y;
    }

    public new void Output()
    {
        base.Output();
        Console.WriteLine("Y: {0}", y);
    }

    public void Calculate()
    {
        if (y == 0)
        {
            Console.WriteLine("Ошибка: деление на ноль.");
            return;
        }
        double result = (double)(x1 - x2) / y;
        Console.WriteLine("Результат (X1 - X2) / Y: {0}", result);
    }
}

// Пример использования
class Program
{
    static void Main()
    {
        Y obj = new Y(10, 5, 2);
        obj.Output();
        obj.Calculate();

        // Демонстрация клонирования с корректным типом
        Y clone = (Y)obj.Clone();
        clone.Input(20, 10, 5);
        clone.Output();
        clone.Calculate();
    }
}
*/

/*using System;

public interface IGeometry
{
    double CalculatePerimeter();  // Вычисление периметра
    double CalculateArea();       // Вычисление площади
}

public abstract class Figure : IGeometry, IComparable<Figure>
{
    // Методы интерфейса IGeometry
    public abstract double CalculatePerimeter();
    public abstract double CalculateArea();

    // Метод IComparable для сортировки по площади
    public int CompareTo(Figure other)
    {
        return CalculateArea().CompareTo(other.CalculateArea());
    }
}

public class Triangle : Figure
{
    private (double, double) A, B, C;

    public Triangle((double, double) a, (double, double) b, (double, double) c)
    {
        A = a;
        B = b;
        C = c;
    }

    private double Distance((double, double) p1, (double, double) p2)
    {
        return Math.Sqrt(Math.Pow(p2.Item1 - p1.Item1, 2) + Math.Pow(p2.Item2 - p1.Item2, 2));
    }

    public override double CalculatePerimeter()
    {
        return Distance(A, B) + Distance(B, C) + Distance(C, A);
    }

    public override double CalculateArea()
    {
        double p = CalculatePerimeter() / 2;
        return Math.Sqrt(p * (p - Distance(A, B)) * (p - Distance(B, C)) * (p - Distance(C, A)));
    }
}

public class Quadrilateral : Figure
{
    private (double, double) A, B, C, D;

    public Quadrilateral((double, double) a, (double, double) b, (double, double) c, (double, double) d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }

    private double Distance((double, double) p1, (double, double) p2)
    {
        return Math.Sqrt(Math.Pow(p2.Item1 - p1.Item1, 2) + Math.Pow(p2.Item2 - p1.Item2, 2));
    }

    public override double CalculatePerimeter()
    {
        return Distance(A, B) + Distance(B, C) + Distance(C, D) + Distance(D, A);
    }

    public override double CalculateArea()
    {
        // Разбиваем четырехугольник на два треугольника и считаем площадь каждого
        double area1 = new Triangle(A, B, C).CalculateArea();
        double area2 = new Triangle(A, C, D).CalculateArea();
        return area1 + area2;
    }
}

class Program
{
    static void Main()
    {
        Figure[] figures = new Figure[]
        {
            new Triangle((0, 0), (1, 0), (0, 1)),
            new Quadrilateral((0, 0), (2, 0), (2, 2), (0, 2)),
            new Triangle((0, 0), (3, 0), (0, 3))
        };

        Array.Sort(figures); // Сортировка по площади

        foreach (Figure fig in figures)
        {
            Console.WriteLine($"Figure: {fig.GetType().Name}, Area: {fig.CalculateArea()}, Perimeter: {fig.CalculatePerimeter()}");
        }
    }
}
*/

/*using System;

public interface ICipher
{
    string Encode(string input);
    string Decode(string input);
}

public class ACipher : ICipher
{
    public string Encode(string input)
    {
        return Shift(input, 1);
    }

    public string Decode(string input)
    {
        return Shift(input, -1);
    }

    private string Shift(string input, int positions)
    {
        char[] output = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsLetter(input[i]))
            {
                char baseChar = char.IsUpper(input[i]) ? 'A' : 'a';
                int offset = (input[i] - baseChar + positions) % 26;
                if (offset < 0) offset += 26;
                output[i] = (char)(baseChar + offset);
            }
            else
            {
                output[i] = input[i];
            }
        }
        return new string(output);
    }
}

public class BCipher : ICipher
{
    public string Encode(string input)
    {
        return Reflect(input);
    }

    public string Decode(string input)
    {
        return Reflect(input); // Обратное преобразование идентично прямому
    }

    private string Reflect(string input)
    {
        char[] output = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsLetter(input[i]))
            {
                char baseChar = char.IsUpper(input[i]) ? 'A' : 'a';
                output[i] = (char)(baseChar + ('Z' - input[i]));
            }
            else
            {
                output[i] = input[i];
            }
        }
        return new string(output);
    }
}

class Program
{
    static void Main()
    {
        string original = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        ICipher aCipher = new ACipher();
        ICipher bCipher = new BCipher();

        Console.WriteLine("Original: " + original);
        Console.WriteLine("ACipher Encoded: " + aCipher.Encode(original));
        Console.WriteLine("ACipher Decoded: " + aCipher.Decode(aCipher.Encode(original)));
        Console.WriteLine("BCipher Encoded: " + bCipher.Encode(original));
        Console.WriteLine("BCipher Decoded: " + bCipher.Decode(bCipher.Encode(original)));
    }
}
*/

/*using System;

public interface IBankomat
{
    string Address { get; set; }  // Адрес банкомата
    bool WithdrawMoney(decimal amount);  // Метод для снятия денег
}

public interface IBankomatPriorbank
{
    int GetBonus();  // Метод для получения бонуса
}

public class BankomatPrior : IBankomat, IBankomatPriorbank
{
    public string Address { get; set; }

    public BankomatPrior(string address)
    {
        Address = address;
    }

    public bool WithdrawMoney(decimal amount)
    {
        Console.WriteLine($"Снятие суммы {amount} выполнено успешно.");
        return true;
    }

    public int GetBonus()
    {
        return 100;  // Возвращаем пример бонуса
    }
}

class Program
{
    static void Main()
    {
        BankomatPrior bankomat = new BankomatPrior("ул. Пушкина, д. 23");

        Console.WriteLine("Адрес банкомата: " + bankomat.Address);
        bankomat.WithdrawMoney(1500);

        int bonus = bankomat.GetBonus();
        Console.WriteLine("Получен бонус: " + bonus);
    }
}
*/


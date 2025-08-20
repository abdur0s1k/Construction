using System;

public class Point
{
    // Поля
    private int x;
    private int y;

    // Конструкторы
    public Point()
    {   
        x = 0;
        y = 0;
    }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    // Методы
    public void DisplayCoordinates()
    {
        Console.WriteLine($"Point coordinates: ({x}, {y})");
    }

    public double DistanceFromOrigin()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public void Move(int a, int b)
    {
        x += a;
        y += b;
    }

    // Свойства
    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public int Scalar
    {
        set
        {
            x *= value;
            y *= value;
        }
    }

    // Индексатор
    public int this[int index]
    {
        get
        {
            return index switch
            {
                0 => x,
                1 => y,
                _ => throw new IndexOutOfRangeException("Invalid index. Use 0 for X or 1 for Y.")
            };
        }
        set
        {
            switch (index)
            {
                case 0:
                    x = value;
                    break;
                case 1:
                    y = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid index. Use 0 for X or 1 for Y.");
            }
        }
    }

    // Перегрузка операций
    public static Point operator ++(Point point)
    {
        point.x++;
        point.y++;
        return point;
    }

    public static Point operator --(Point point)
    {
        point.x--;
        point.y--;
        return point;
    }

    public static bool operator true(Point point)
    {
        return point.x == point.y;
    }

    public static bool operator false(Point point)
    {
        return point.x != point.y;
    }

    public static Point operator +(Point point, int scalar)
    {
        return new Point(point.x + scalar, point.y + scalar);
    }

    // Тестирование
    public static void Main(string[] args)
    {
        Point p1 = new Point(3, 4);
        p1.DisplayCoordinates();

        Console.WriteLine($"Distance from origin: {p1.DistanceFromOrigin()}");

        p1.Move(2, 3);
        p1.DisplayCoordinates();

        Console.WriteLine($"Value of x through indexer: {p1[0]}");
        Console.WriteLine($"Value of y through indexer: {p1[1]}");

        p1.Scalar = 2;
        p1.DisplayCoordinates();

        p1++;
        p1.DisplayCoordinates();

        if (p1)
        {
            Console.WriteLine("x and y are equal.");
        }
        else
        {
            Console.WriteLine("x and y are not equal.");
        }

        Point p2 = p1 + 5;
        p2.DisplayCoordinates();
    }
}

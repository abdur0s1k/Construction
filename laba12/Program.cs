/*using System;

class Parent
{
    // Поля родительского класса
    public double x;
    public double y;

    // Конструктор родительского класса
    public Parent(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    // Метод для отображения данных о родительском объекте
    public virtual void Display()
    {
        Console.WriteLine($"Parent: x = {x}, y = {y}");
    }
}

class Child : Parent
{
    // Дополнительное поле в дочернем классе
    public double z;

    // Конструктор дочернего класса
    public Child(double x, double y, double z) : base(x, y)
    {
        this.z = z;
    }

    // Метод для обработки данных (вычисление выражения)
    public double Process()
    {
        return (x * x + y * y) / z;
    }

    // Переопределенный метод для отображения данных о дочернем объекте
    public override void Display()
    {
        base.Display();  // Вызов Display родительского класса
        Console.WriteLine($"Child: z = {z}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание объектов родительского и дочернего классов
        Parent parentObj = new Parent(3.0, 4.0);
        Child childObj = new Child(3.0, 4.0, 5.0);

        // Отображение информации о родительском объекте
        Console.WriteLine("Parent Object:");
        parentObj.Display();

        // Отображение информации о дочернем объекте
        Console.WriteLine("\nChild Object:");
        childObj.Display();

        // Вычисление и вывод результата обработки в дочернем классе
        double result = childObj.Process();
        Console.WriteLine($"\nResult of processing in child: {result}");
    }
}
*/

/*using System;

class Book
{
    // Поля родительского класса
    private string title;
    private string author;
    private int year;

    // Конструктор родительского класса
    public Book(string title, string author, int year)
    {
        this.title = title;
        this.author = author;
        this.year = year;
    }

    // Геттеры и сеттеры для полей
    public string GetTitle()
    {
        return title;
    }

    public void SetTitle(string title)
    {
        this.title = title;
    }

    public string GetAuthor()
    {
        return author;
    }

    public void SetAuthor(string author)
    {
        this.author = author;
    }

    public int GetYear()
    {
        return year;
    }

    public void SetYear(int year)
    {
        this.year = year;
    }

    // Метод для отображения данных о книге
    public virtual string GetInfo()
    {
        return $"Book: Title = {title}, Author = {author}, Year = {year}";
    }
}

class BookStore : Book
{
    // Дополнительное поле в дочернем классе
    private double price;

    // Конструктор дочернего класса
    public BookStore(string title, string author, int year, double price)
        : base(title, author, year)
    {
        this.price = price;
    }

    // Геттер и сеттер для поля price
    public double GetPrice()
    {
        return price;
    }

    public void SetPrice(double price)
    {
        this.price = price;
    }

    // Функция обработки данных: уменьшение стоимости книги на 20%, если книге больше 5 лет
    public void DiscountPrice()
    {
        int currentYear = DateTime.Now.Year;
        if (currentYear - GetYear() > 5)
        {
            price -= price * 0.2;
        }
    }

    // Переопределенная функция для формирования строки информации об объекте
    public override string GetInfo()
    {
        return base.GetInfo() + $", Price = {price:F2}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание объектов родительского и дочернего классов
        Book bookObj = new Book("C# Programming", "John Doe", 2015);
        BookStore bookStoreObj = new BookStore("Learn C# Quickly", "Jane Smith", 2010, 500.0);

        // Отображение информации о родительском объекте
        Console.WriteLine("Book Object:");
        Console.WriteLine(bookObj.GetInfo());

        // Отображение информации о дочернем объекте
        Console.WriteLine("\nBookStore Object:");
        Console.WriteLine(bookStoreObj.GetInfo());

        // Применение скидки, если книга старше 5 лет
        bookStoreObj.DiscountPrice();

        // Отображение информации о дочернем объекте после применения скидки
        Console.WriteLine("\nBookStore Object After Discount:");
        Console.WriteLine(bookStoreObj.GetInfo());
    }
}
*/

/**/

/**/

/**/
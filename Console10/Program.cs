/*using System;

namespace CompanyEmployees
{
    // Базовый класс "Работник фирмы"
    public class РаботникФирмы
    {
        private string имя;
        private string фамилия;
        private int стаж;
        protected string должность;

        // Конструктор без параметров
        public РаботникФирмы()
        {
            имя = "Неизвестно";
            фамилия = "Неизвестно";
            стаж = 0;
            должность = "Неизвестно";
        }

        // Конструктор с параметрами
        public РаботникФирмы(string имя, string фамилия, int стаж)
        {
            this.имя = имя;
            this.фамилия = фамилия;
            this.стаж = стаж;
            this.должность = "Работник фирмы";
        }

        // Методы для доступа к полю Имя
        public string ПолучитьИмя()
        {
            return имя;
        }

        public void УстановитьИмя(string значение)
        {
            имя = значение;
        }

        // Методы для доступа к полю Фамилия
        public string ПолучитьФамилию()
        {
            return фамилия;
        }

        public void УстановитьФамилию(string значение)
        {
            фамилия = значение;
        }

        // Методы для доступа к полю Стаж
        public int ПолучитьСтаж()
        {
            return стаж;
        }

        public void УстановитьСтаж(int значение)
        {
            if (значение >= 0)
                стаж = значение;
            else
                Console.WriteLine("Стаж не может быть отрицательным.");
        }

        // Метод для доступа к полю Должность
        public string ПолучитьДолжность()
        {
            return должность;
        }

        // Метод проверки существования объекта
        public bool Существует()
        {
            return !string.IsNullOrEmpty(имя) && !string.IsNullOrEmpty(фамилия);
        }

        // Перегрузка метода ToString
        public override string ToString()
        {
            return $"Имя: {имя}, Фамилия: {фамилия}, Должность: {должность}, Стаж: {стаж} лет.";
        }
    }

    // Производный класс "Менеджер"
    public class Менеджер : РаботникФирмы
    {
        public Менеджер(string имя, string фамилия, int стаж)
            : base(имя, фамилия, стаж)
        {
            должность = "Менеджер";
        }
    }

    // Производный класс "Администратор"
    public class Администратор : РаботникФирмы
    {
        public Администратор(string имя, string фамилия, int стаж)
            : base(имя, фамилия, стаж)
        {
            должность = "Администратор";
        }
    }

    // Производный класс "Программист"
    public class Программист : РаботникФирмы
    {
        public Программист(string имя, string фамилия, int стаж)
            : base(имя, фамилия, стаж)
        {
            должность = "Программист";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание объектов
            РаботникФирмы работник1 = new РаботникФирмы("Иван", "Иванов", 5);
            Менеджер менеджер1 = new Менеджер("Анна", "Сидорова", 7);
            Администратор администратор1 = new Администратор("Петр", "Петров", 3);
            Программист программист1 = new Программист("Елена", "Кузнецова", 10);

            // Вывод информации
            Console.WriteLine(работник1);
            Console.WriteLine(менеджер1);
            Console.WriteLine(администратор1);
            Console.WriteLine(программист1);

            // Проверка существования объекта
            Console.WriteLine($"Объект {работник1.ПолучитьИмя()} существует? {работник1.Существует()}");

            // Пример изменения имени и стажа
            работник1.УстановитьИмя("Сергей");
            работник1.УстановитьСтаж(10);
            Console.WriteLine(работник1);
        }
    }
}
*/

/*using System;

namespace MusicianHierarchy
{
    // Базовый класс "Музыкант"
    public class Музыкант
    {
        private string имя;
        private string инструмент;
        private int опыт; // Опыт в годах

        // Конструктор без параметров
        public Музыкант()
        {
            имя = "Неизвестно";
            инструмент = "Неизвестно";
            опыт = 0;
        }

        // Конструктор с параметрами
        public Музыкант(string имя, string инструмент, int опыт)
        {
            this.имя = имя;
            this.инструмент = инструмент;
            this.опыт = опыт;
        }

        // Методы для доступа к имени
        public string ПолучитьИмя()
        {
            return имя;
        }

        public void УстановитьИмя(string значение)
        {
            имя = значение;
        }

        // Методы для доступа к инструменту
        public string ПолучитьИнструмент()
        {
            return инструмент;
        }

        public void УстановитьИнструмент(string значение)
        {
            инструмент = значение;
        }

        // Методы для доступа к опыту
        public int ПолучитьОпыт()
        {
            return опыт;
        }

        public void УстановитьОпыт(int значение)
        {
            if (значение >= 0)
                опыт = значение;
            else
                Console.WriteLine("Опыт не может быть отрицательным.");
        }

        // Метод для игры на инструменте
        public virtual void Играть()
        {
            Console.WriteLine($"{имя} играет на {инструмент}.");
        }

        // Перегрузка метода ToString
        public override string ToString()
        {
            return $"Имя: {имя}, Инструмент: {инструмент}, Опыт: {опыт} лет.";
        }
    }

    // Производный класс "Барабанщик"
    public class Барабанщик : Музыкант
    {
        public Барабанщик(string имя, int опыт)
            : base(имя, "Барабаны", опыт)
        {
        }

        public override void Играть()
        {
            Console.WriteLine($"{ПолучитьИмя()} устраивает ритм-шоу на барабанах!");
        }
    }

    // Производный класс "Скрипач"
    public class Скрипач : Музыкант
    {
        public Скрипач(string имя, int опыт)
            : base(имя, "Скрипка", опыт)
        {
        }

        public override void Играть()
        {
            Console.WriteLine($"{ПолучитьИмя()} виртуозно исполняет мелодию на скрипке.");
        }
    }

    // Производный класс "Пианист"
    public class Пианист : Музыкант
    {
        public Пианист(string имя, int опыт)
            : base(имя, "Пианино", опыт)
        {
        }

        public override void Играть()
        {
            Console.WriteLine($"{ПолучитьИмя()} исполняет классическое произведение на пианино.");
        }
    }

    // Производный класс "Гитарист"
    public class Гитарист : Музыкант
    {
        public Гитарист(string имя, int опыт)
            : base(имя, "Гитара", опыт)
        {
        }

        public override void Играть()
        {
            Console.WriteLine($"{ПолучитьИмя()} зажигает публику своим выступлением на гитаре!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание объектов
            Музыкант музыкант = new Музыкант("Иван", "Флейта", 3);
            Барабанщик барабанщик = new Барабанщик("Петр", 5);
            Скрипач скрипач = new Скрипач("Анна", 7);
            Пианист пианист = new Пианист("Елена", 10);
            Гитарист гитарист = new Гитарист("Максим", 4);

            // Демонстрация методов
            Console.WriteLine(музыкант);
            музыкант.Играть();

            Console.WriteLine(барабанщик);
            барабанщик.Играть();

            Console.WriteLine(скрипач);
            скрипач.Играть();

            Console.WriteLine(пианист);
            пианист.Играть();

            Console.WriteLine(гитарист);
            гитарист.Играть();
        }
    }
}
*/

/*using System;

namespace Geometry
{
    // Базовый класс "Точка"
    public class Point
    {
        private string color;  // Цвет
        private bool isVisible; // Видимость

        // Конструктор без параметров
        public Point()
        {
            color = "Black";
            isVisible = true;
        }

        // Конструктор с параметрами
        public Point(string color, bool isVisible)
        {
            this.color = color;
            this.isVisible = isVisible;
        }

        // Свойства для доступа
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        // Метод для передвижения по горизонтали
        public virtual void MoveHorizontal(int delta)
        {
            Console.WriteLine($"Точка перемещена по горизонтали на {delta} единиц.");
        }

        // Метод для передвижения по вертикали
        public virtual void MoveVertical(int delta)
        {
            Console.WriteLine($"Точка перемещена по вертикали на {delta} единиц.");
        }

        // Метод изменения цвета
        public virtual void ChangeColor(string newColor)
        {
            color = newColor;
            Console.WriteLine($"Цвет изменен на {newColor}.");
        }

        // Метод для вывода состояния объекта
        public virtual void Display()
        {
            Console.WriteLine($"Точка: Цвет = {color}, Видимость = {(isVisible ? "Видимая" : "Невидимая")}");
        }
    }

    // Класс "Окружность", наследуется от Point
    public class Circle : Point
    {
        private int radius; // Радиус окружности

        // Конструктор с параметрами
        public Circle(string color, bool isVisible, int radius)
            : base(color, isVisible)
        {
            this.radius = radius;
        }

        // Метод вычисления площади окружности
        public double CalculateArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        // Переопределение метода вывода состояния объекта
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Окружность: Радиус = {radius}, Площадь = {CalculateArea():F2}");
        }

        // Переопределение методов перемещения
        public override void MoveHorizontal(int delta)
        {
            base.MoveHorizontal(delta);
            Console.WriteLine("Окружность перемещена по горизонтали.");
        }

        public override void MoveVertical(int delta)
        {
            base.MoveVertical(delta);
            Console.WriteLine("Окружность перемещена по вертикали.");
        }

        // Переопределение метода изменения цвета
        public override void ChangeColor(string newColor)
        {
            base.ChangeColor(newColor);
            Console.WriteLine("Цвет окружности изменен.");
        }
    }

    // Класс "Прямоугольник", наследуется от Point
    public class Rectangle : Point
    {
        private int width;  // Ширина
        private int height; // Высота

        // Конструктор с параметрами
        public Rectangle(string color, bool isVisible, int width, int height)
            : base(color, isVisible)
        {
            this.width = width;
            this.height = height;
        }

        // Метод вычисления площади прямоугольника
        public int CalculateArea()
        {
            return width * height;
        }

        // Переопределение метода вывода состояния объекта
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Прямоугольник: Ширина = {width}, Высота = {height}, Площадь = {CalculateArea()}");
        }

        // Переопределение методов перемещения
        public override void MoveHorizontal(int delta)
        {
            base.MoveHorizontal(delta);
            Console.WriteLine("Прямоугольник перемещен по горизонтали.");
        }

        public override void MoveVertical(int delta)
        {
            base.MoveVertical(delta);
            Console.WriteLine("Прямоугольник перемещен по вертикали.");
        }

        // Переопределение метода изменения цвета
        public override void ChangeColor(string newColor)
        {
            base.ChangeColor(newColor);
            Console.WriteLine("Цвет прямоугольника изменен.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание объектов
            Point point = new Point("Red", true);
            Circle circle = new Circle("Blue", true, 5);
            Rectangle rectangle = new Rectangle("Green", true, 10, 20);

            // Демонстрация работы методов
            Console.WriteLine("Точка:");
            point.Display();
            point.MoveHorizontal(5);
            point.MoveVertical(10);
            point.ChangeColor("Yellow");
            point.Display();

            Console.WriteLine("\nОкружность:");
            circle.Display();
            circle.MoveHorizontal(10);
            circle.MoveVertical(15);
            circle.ChangeColor("Purple");
            circle.Display();

            Console.WriteLine("\nПрямоугольник:");
            rectangle.Display();
            rectangle.MoveHorizontal(20);
            rectangle.MoveVertical(25);
            rectangle.ChangeColor("Orange");
            rectangle.Display();
        }
    }
}
*/

/*using System;
using System.Collections.Generic;

namespace PublishingCatalog
{
    // Абстрактный класс "Издание"
    public abstract class Edition
    {
        private string title;  // Название
        private string author; // Фамилия автора

        // Конструктор
        public Edition(string title, string author)
        {
            this.title = title;
            this.author = author;
        }

        // Геттеры и сеттеры для поля Title
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        // Геттеры и сеттеры для поля Author
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        // Абстрактный метод для вывода информации
        public abstract void DisplayInfo();

        // Метод для проверки, является ли издание искомым по фамилии автора
        public bool IsAuthor(string author)
        {
            return this.author.Equals(author, StringComparison.OrdinalIgnoreCase);
        }
    }

    // Класс "Книга"
    public class Book : Edition
    {
        private int year;        // Год издания
        private string publisher; // Издательство

        // Конструктор
        public Book(string title, string author, int year, string publisher)
            : base(title, author)
        {
            this.year = year;
            this.publisher = publisher;
        }

        // Геттеры и сеттеры для полей
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        // Реализация метода DisplayInfo для книги
        public override void DisplayInfo()
        {
            Console.WriteLine($"Книга: {Title}, Автор: {Author}, Год издания: {Year}, Издательство: {Publisher}");
        }
    }

    // Класс "Статья"
    public class Article : Edition
    {
        private string journalName;  // Название журнала
        private int journalNumber;   // Номер журнала
        private int year;            // Год издания

        // Конструктор
        public Article(string title, string author, string journalName, int journalNumber, int year)
            : base(title, author)
        {
            this.journalName = journalName;
            this.journalNumber = journalNumber;
            this.year = year;
        }

        // Геттеры и сеттеры для полей
        public string JournalName
        {
            get { return journalName; }
            set { journalName = value; }
        }

        public int JournalNumber
        {
            get { return journalNumber; }
            set { journalNumber = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        // Реализация метода DisplayInfo для статьи
        public override void DisplayInfo()
        {
            Console.WriteLine($"Статья: {Title}, Автор: {Author}, Журнал: {JournalName}, Номер: {JournalNumber}, Год издания: {Year}");
        }
    }

    // Класс "Электронный ресурс"
    public class Ebook : Edition
    {
        private string link;        // Ссылка на ресурс
        private string description; // Аннотация

        // Конструктор
        public Ebook(string title, string author, string link, string description)
            : base(title, author)
        {
            this.link = link;
            this.description = description;
        }

        // Геттеры и сеттеры для полей
        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // Реализация метода DisplayInfo для электронного ресурса
        public override void DisplayInfo()
        {
            Console.WriteLine($"Электронный ресурс: {Title}, Автор: {Author}, Ссылка: {Link}, Аннотация: {Description}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем каталог из n изданий
            List<Edition> catalog = new List<Edition>
            {
                new Book("C# для начинающих", "Иванов И.И.", 2020, "Издательство А"),
                new Article("Новые технологии в программировании", "Петров П.П.", "Программирование сегодня", 12, 2023),
                new Ebook("Введение в .NET", "Сидоров С.С.", "http://example.com", "Краткий обзор возможностей .NET")
            };

            // Вывод полной информации из каталога
            Console.WriteLine("Информация о всех изданиях в каталоге:");
            foreach (var edition in catalog)
            {
                edition.DisplayInfo();
                Console.WriteLine(); // Добавляем пустую строку для разделения
            }

            // Организуем поиск изданий по фамилии автора
            Console.WriteLine("Введите фамилию автора для поиска:");
            string searchAuthor = Console.ReadLine();

            Console.WriteLine($"\nРезультаты поиска по автору '{searchAuthor}':");
            bool found = false;
            foreach (var edition in catalog)
            {
                if (edition.IsAuthor(searchAuthor))
                {
                    edition.DisplayInfo();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Издания с таким автором не найдены.");
            }
        }
    }
}
*/

/*using System;
using System.Collections.Generic;
using System.Linq;

// Абстрактный базовый класс "Работник"
public abstract class Employee
{
    public int Id { get; set; }    // Идентификатор работника
    public string Name { get; set; } // Имя работника

    // Конструктор
    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }

    // Абстрактный метод для расчета среднемесячной заработной платы
    public abstract double CalculateMonthlySalary();
}

// Класс "Работник с почасовой оплатой"
public class HourlyEmployee : Employee
{
    public double HourlyRate { get; set; } // Почасовая ставка

    // Конструктор
    public HourlyEmployee(int id, string name, double hourlyRate)
        : base(id, name)
    {
        HourlyRate = hourlyRate;
    }

    // Реализация метода для расчета среднемесячной заработной платы
    public override double CalculateMonthlySalary()
    {
        return 20.8 * 8 * HourlyRate;  // 20.8 дней в месяц, 8 часов в день
    }
}

// Класс "Работник с фиксированной оплатой"
public class FixedSalaryEmployee : Employee
{
    public double FixedSalary { get; set; } // Фиксированная месячная оплата

    // Конструктор
    public FixedSalaryEmployee(int id, string name, double fixedSalary)
        : base(id, name)
    {
        FixedSalary = fixedSalary;
    }

    // Реализация метода для расчета среднемесячной заработной платы
    public override double CalculateMonthlySalary()
    {
        return FixedSalary; // Фиксированная месячная зарплата
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем список работников
        List<Employee> employees = new List<Employee>
        {
            new HourlyEmployee(1, "Иванов Иван", 500),
            new FixedSalaryEmployee(2, "Петров Петр", 40000),
            new HourlyEmployee(3, "Сидоров Сергей", 600),
            new FixedSalaryEmployee(4, "Михайлов Михаил", 50000),
            new HourlyEmployee(5, "Кузнецов Алексей", 450),
            new FixedSalaryEmployee(6, "Новиков Николай", 45000)
        };

        // Упорядочиваем список работников по среднемесячной заработной плате по убыванию
        // При совпадении зарплаты - по алфавиту по имени
        var sortedEmployees = employees
            .OrderByDescending(e => e.CalculateMonthlySalary())
            .ThenBy(e => e.Name)
            .ToList();

        // Выводим идентификатор работника, имя и среднемесячный заработок для всех работников
        Console.WriteLine("Идентификатор, Имя, Среднемесячная заработная плата:");
        foreach (var employee in sortedEmployees)
        {
            Console.WriteLine($"{employee.Id} - {employee.Name}: {employee.CalculateMonthlySalary():0.00} рублей");
        }

        // Выводим первые пять имен работников
        Console.WriteLine("\nПервые пять работников:");
        foreach (var employee in sortedEmployees.Take(5))
        {
            Console.WriteLine(employee.Name);
        }

        // Выводим последние три идентификатора работников
        Console.WriteLine("\nПоследние три работника (по идентификатору):");
        foreach (var employee in sortedEmployees.Skip(Math.Max(0, sortedEmployees.Count - 3)))
        {
            Console.WriteLine(employee.Id);
        }
    }
}
*/

/*using System;
using System.Collections.Generic;

// Абстрактный класс Edition
public abstract class Edition : IComparable<Edition>
{
    private string title;  // Название издания
    private string author; // Фамилия автора

    // Конструктор
    public Edition(string title, string author)
    {
        this.title = title;
        this.author = author;
    }

    // Свойства для доступа к полям
    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    // Абстрактный метод для вывода информации о издании
    public abstract void DisplayInfo();

    // Метод для проверки, является ли издание искомым по фамилии автора
    public bool IsAuthor(string author)
    {
        return this.author.Equals(author, StringComparison.OrdinalIgnoreCase);
    }

    // Реализация интерфейса IComparable для сортировки по фамилии автора
    public int CompareTo(Edition other)
    {
        if (other == null) return 1;

        return string.Compare(this.author, other.author, StringComparison.OrdinalIgnoreCase);
    }
}

// Класс "Книга"
public class Book : Edition
{
    private int year;       // Год издания
    private string publisher; // Издательство

    // Конструктор
    public Book(string title, string author, int year, string publisher)
        : base(title, author)
    {
        this.year = year;
        this.publisher = publisher;
    }

    // Свойства для доступа к полям
    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }

    // Реализация метода для вывода информации о книге
    public override void DisplayInfo()
    {
        Console.WriteLine($"Книга: {Title}, Автор: {Author}, Год издания: {Year}, Издательство: {Publisher}");
    }
}

// Класс "Статья"
public class Article : Edition
{
    private string journal;  // Название журнала
    private int issueNumber; // Номер журнала
    private int year;        // Год издания

    // Конструктор
    public Article(string title, string author, string journal, int issueNumber, int year)
        : base(title, author)
    {
        this.journal = journal;
        this.issueNumber = issueNumber;
        this.year = year;
    }

    // Свойства для доступа к полям
    public string Journal
    {
        get { return journal; }
        set { journal = value; }
    }

    public int IssueNumber
    {
        get { return issueNumber; }
        set { issueNumber = value; }
    }

    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    // Реализация метода для вывода информации о статье
    public override void DisplayInfo()
    {
        Console.WriteLine($"Статья: {Title}, Автор: {Author}, Журнал: {Journal}, Номер: {IssueNumber}, Год издания: {Year}");
    }
}

// Класс "Онлайн-ресурс"
public class OnlineResource : Edition
{
    private string link;      // Ссылка на ресурс
    private string annotation; // Аннотация

    // Конструктор
    public OnlineResource(string title, string author, string link, string annotation)
        : base(title, author)
    {
        this.link = link;
        this.annotation = annotation;
    }

    // Свойства для доступа к полям
    public string Link
    {
        get { return link; }
        set { link = value; }
    }

    public string Annotation
    {
        get { return annotation; }
        set { annotation = value; }
    }

    // Реализация метода для вывода информации о онлайн-ресурсе
    public override void DisplayInfo()
    {
        Console.WriteLine($"Онлайн-ресурс: {Title}, Автор: {Author}, Ссылка: {Link}, Аннотация: {Annotation}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем список изданий
        List<Edition> catalog = new List<Edition>
        {
            new Book("C# для начинающих", "Иванов И.И.", 2020, "Издательство А"),
            new Article("Новые технологии в программировании", "Петров П.П.", "Программирование сегодня", 12, 2023),
            new OnlineResource("Введение в .NET", "Сидоров С.С.", "http://example.com", "Краткий обзор возможностей .NET"),
            new Book("Алгоритмы и структуры данных", "Иванов И.И.", 2019, "Издательство Б"),
            new Article("Обзор языков программирования", "Петров П.П.", "Технологии будущего", 5, 2022),
            new OnlineResource("Технологии облачных вычислений", "Сидоров С.С.", "http://cloud.com", "Основы облачных технологий")
        };

        // Сортируем каталог по фамилии автора
        catalog.Sort();

        // Выводим полную информацию из каталога
        Console.WriteLine("Полная информация о всех изданиях:");
        foreach (var edition in catalog)
        {
            edition.DisplayInfo();
            Console.WriteLine(); // Пустая строка для разделения
        }

        // Организуем поиск изданий по фамилии автора
        Console.WriteLine("Введите фамилию автора для поиска:");
        string searchAuthor = Console.ReadLine();

        Console.WriteLine($"\nРезультаты поиска по автору '{searchAuthor}':");
        bool found = false;
        foreach (var edition in catalog)
        {
            if (edition.IsAuthor(searchAuthor))
            {
                edition.DisplayInfo();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Издания с таким автором не найдены.");
        }
    }
}
*/
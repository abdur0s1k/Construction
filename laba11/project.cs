/*using System;
using System.Collections.Generic;
using System.IO;

public class SubjectIndex
{
    // Скрытые поля
    private string word;
    private List<int> pageNumbers;

    // Конструктор без параметров
    public SubjectIndex()
    {
        word = string.Empty;
        pageNumbers = new List<int>();
    }

    // Конструктор с параметрами
    public SubjectIndex(string word, List<int> pageNumbers)
    {
        if (string.IsNullOrEmpty(word))
            throw new ArgumentException("Слово не может быть пустым.");
        
        if (pageNumbers == null || pageNumbers.Count == 0 || pageNumbers.Count > 10)
            throw new ArgumentException("Количество страниц должно быть от 1 до 10.");
        
        this.word = word;
        this.pageNumbers = new List<int>(pageNumbers);
    }

    // Свойства для доступа к данным
    public string Word
    {
        get { return word; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Слово не может быть пустым.");
            word = value;
        }
    }

    public List<int> PageNumbers
    {
        get { return pageNumbers; }
        set
        {
            if (value == null || value.Count == 0 || value.Count > 10)
                throw new ArgumentException("Количество страниц должно быть от 1 до 10.");
            pageNumbers = new List<int>(value);
        }
    }

    // Метод для вывода всех страниц для данного слова
    public void DisplayPages()
    {
        Console.WriteLine($"Слово: {word}");
        Console.WriteLine("Номера страниц: " + string.Join(", ", pageNumbers));
    }

    // Индексатор для доступа к страницам
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= pageNumbers.Count)
                throw new IndexOutOfRangeException("Неверный индекс.");
            return pageNumbers[index];
        }
        set
        {
            if (index < 0 || index >= pageNumbers.Count)
                throw new IndexOutOfRangeException("Неверный индекс.");
            pageNumbers[index] = value;
        }
    }

    // Перегрузка операции добавления номера страницы
    public void AddPage(int pageNumber)
    {
        if (pageNumbers.Count >= 10)
            throw new InvalidOperationException("Максимальное количество страниц — 10.");
        
        if (pageNumbers.Contains(pageNumber))
            throw new InvalidOperationException("Этот номер страницы уже существует.");
        
        pageNumbers.Add(pageNumber);
    }

    // Метод для удаления страницы
    public bool RemovePage(int pageNumber)
    {
        return pageNumbers.Remove(pageNumber);
    }

    // Метод для вывода информации о слове и его страницах
    public static void DisplayIndex(List<SubjectIndex> index)
    {
        foreach (var item in index)
        {
            item.DisplayPages();
        }
    }

    // Метод для формирования указателя с клавиатуры
    public static List<SubjectIndex> CreateIndexFromInput()
    {
        var index = new List<SubjectIndex>();
        string word;
        do
        {
            Console.Write("Введите слово (или 'exit' для выхода): ");
            word = Console.ReadLine();
            if (word.ToLower() == "exit") break;

            Console.Write("Введите номера страниц (через запятую): ");
            var pagesInput = Console.ReadLine();
            var pageNumbers = new List<int>();

            foreach (var page in pagesInput.Split(','))
            {
                if (int.TryParse(page.Trim(), out int pageNumber))
                {
                    pageNumbers.Add(pageNumber);
                }
            }

            try
            {
                index.Add(new SubjectIndex(word, pageNumbers));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        } while (true);
        
        return index;
    }

    // Метод для формирования указателя из файла
    public static List<SubjectIndex> CreateIndexFromFile(string filePath)
    {
        var index = new List<SubjectIndex>();

        try
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string word = parts[0].Trim();
                    var pageNumbers = new List<int>();

                    foreach (var page in parts[1].Split(','))
                    {
                        if (int.TryParse(page.Trim(), out int pageNumber))
                        {
                            pageNumbers.Add(pageNumber);
                        }
                    }

                    try
                    {
                        index.Add(new SubjectIndex(word, pageNumbers));
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Ошибка в строке '{line}': {ex.Message}");
                    }
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
        }

        return index;
    }

    // Перегрузка операции сравнения для поиска слов
    public static bool operator ==(SubjectIndex a, SubjectIndex b)
    {
        return a.word == b.word;
    }

    public static bool operator !=(SubjectIndex a, SubjectIndex b)
    {
        return !(a == b);
    }

    // Переопределение методов Equals и GetHashCode
    public override bool Equals(object obj)
    {
        if (obj is SubjectIndex other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return word.GetHashCode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Пример создания указателя с клавиатуры
            var index = SubjectIndex.CreateIndexFromInput();
            SubjectIndex.DisplayIndex(index);

            // Пример создания указателя из файла
            string filePath = "index.txt"; // Убедитесь, что файл существует в каталоге
            var indexFromFile = SubjectIndex.CreateIndexFromFile(filePath);
            SubjectIndex.DisplayIndex(indexFromFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
*/

/*using System;
using System.Collections.Generic;
using System.Linq;

public class Text
{
    private List<string> sentences;

    // Конструктор без параметров
    public Text()
    {
        sentences = new List<string>();
    }

    // Конструктор с параметром
    public Text(string text)
    {
        sentences = text.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => s.Trim() + ".")
                        .ToList();
    }

    // Метод для вставки предложения
    public void InsertSentence(string sentence)
    {
        if (string.IsNullOrWhiteSpace(sentence))
            throw new ArgumentException("Предложение не может быть пустым.");
        sentences.Add(sentence);
    }

    // Метод для подсчета количества символов в тексте
    public int CountCharacters()
    {
        return string.Join(" ", sentences).Length;
    }

    // Метод для подсчета количества слов в тексте
    public int CountWords()
    {
        return string.Join(" ", sentences).Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    // Метод для подсчета количества предложений в тексте
    public int CountSentences()
    {
        return sentences.Count;
    }

    // Метод для получения предложения по номеру
    public string GetSentenceByNumber(int number)
    {
        if (number < 1 || number > sentences.Count)
            throw new ArgumentOutOfRangeException("Номер предложения выходит за пределы текста.");
        return sentences[number - 1];
    }

    // Метод для получения самого длинного предложения
    public string GetLongestSentence()
    {
        if (sentences.Count == 0)
            throw new InvalidOperationException("Текст пуст.");
        return sentences.OrderByDescending(s => s.Length).First();
    }

    // Метод для получения самого короткого предложения
    public string GetShortestSentence()
    {
        if (sentences.Count == 0)
            throw new InvalidOperationException("Текст пуст.");
        return sentences.OrderBy(s => s.Length).First();
    }

    // Метод для проверки, есть ли в тексте заданное предложение
    public bool ContainsSentence(string sentence)
    {
        return sentences.Contains(sentence);
    }

    // Перегрузка оператора добавления предложения в текст
    public static Text operator +(Text text, string sentence)
    {
        text.InsertSentence(sentence);
        return text;
    }

    // Перегрузка оператора удаления предложения из текста
    public static Text operator -(Text text, string sentence)
    {
        text.sentences.Remove(sentence);
        return text;
    }

    // Перегрузка оператора для сравнения двух текстов
    public static bool operator ==(Text text1, Text text2)
    {
        return text1.sentences.SequenceEqual(text2.sentences);
    }

    public static bool operator !=(Text text1, Text text2)
    {
        return !(text1 == text2);
    }

    // Переопределение метода Equals для сравнения двух объектов Text
    public override bool Equals(object obj)
    {
        if (obj is Text other)
        {
            return this == other;
        }
        return false;
    }

    // Переопределение метода GetHashCode
    public override int GetHashCode()
    {
        return string.Join(" ", sentences).GetHashCode();
    }

    // Метод для вывода текста
    public override string ToString()
    {
        return string.Join(" ", sentences);
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Создание экземпляра текста
            var text = new Text("Это первое предложение. Это второе предложение.");

            // Вставка нового предложения
            text.InsertSentence("Это третье предложение.");

            // Вывод общего количества символов, слов и предложений
            Console.WriteLine($"Количество символов: {text.CountCharacters()}");
            Console.WriteLine($"Количество слов: {text.CountWords()}");
            Console.WriteLine($"Количество предложений: {text.CountSentences()}");

            // Получение предложения по номеру
            Console.WriteLine($"2-е предложение: {text.GetSentenceByNumber(2)}");

            // Получение самого длинного и самого короткого предложения
            Console.WriteLine($"Самое длинное предложение: {text.GetLongestSentence()}");
            Console.WriteLine($"Самое короткое предложение: {text.GetShortestSentence()}");

            // Проверка наличия предложения в тексте
            Console.WriteLine($"Есть ли 'Это первое предложение.': {text.ContainsSentence("Это первое предложение.")}");

            // Перегрузка оператора добавления
            text += "Это четвертое предложение.";
            Console.WriteLine($"После добавления нового предложения: {text}");

            // Перегрузка оператора удаления
            text -= "Это первое предложение.";
            Console.WriteLine($"После удаления первого предложения: {text}");

            // Сравнение двух текстов
            var text2 = new Text("Это второе предложение. Это третье предложение.");
            Console.WriteLine($"Тексты одинаковы: {text == text2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
*/

/*using System;
using System.Collections;

public enum AccountType
{
    Current,   // Текущий счет
    Savings    // Сберегательный счет
}

public class BankTransaction
{
    // Поля только для чтения
    private readonly decimal amount;
    private readonly DateTime transactionDate;

    // Конструктор для создания транзакции
    public BankTransaction(decimal amount)
    {
        this.amount = amount;
        this.transactionDate = DateTime.Now;
    }

    // Переопределение ToString для отображения транзакции
    public override string ToString()
    {
        return $"Дата: {transactionDate}, Сумма: {amount:C}";
    }

    // Свойства для получения данных транзакции
    public decimal Amount
    {
        get { return amount; }
    }

    public DateTime TransactionDate
    {
        get { return transactionDate; }
    }
}

public class BankAccount
{
    // Закрытые поля
    private static int accountNumberSeed = 100000; // Начальный номер счета для генерации новых
    private int accountNumber;
    private decimal balance;
    private AccountType accountType;
    private string accountHolder;

    // Очередь для хранения транзакций
    private Queue transactions;

    // Свойство для номера счета (только для чтения)
    private int AccountNumber
    {
        get { return accountNumber; }
    }

    // Свойство для типа счета (только для чтения)
    private AccountType AccountType
    {
        get { return accountType; }
    }

    // Свойство для имени владельца счета (с возможностью чтения и записи)
    public string AccountHolder
    {
        get { return accountHolder; }
        set { accountHolder = value; }
    }

    // Свойство для баланса (только для чтения)
    public decimal Balance
    {
        get { return balance; }
    }

    // Конструктор по умолчанию
    public BankAccount()
    {
        accountNumber = GenerateAccountNumber();
        balance = 0;
        accountType = AccountType.Current;
        transactions = new Queue();
    }

    // Конструктор для задания только баланса
    public BankAccount(decimal initialBalance) : this()
    {
        balance = initialBalance;
    }

    // Конструктор для задания типа счета
    public BankAccount(AccountType type) : this()
    {
        accountType = type;
    }

    // Конструктор для задания баланса и типа счета
    public BankAccount(decimal initialBalance, AccountType type) : this()
    {
        balance = initialBalance;
        accountType = type;
    }

    // Метод для генерации номера счета
    private int GenerateAccountNumber()
    {
        return accountNumberSeed++;
    }

    // Метод для снятия со счета
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма для снятия должна быть положительной.");
        if (amount > balance)
            throw new InvalidOperationException("Недостаточно средств на счете.");
        
        balance -= amount;
        RecordTransaction(-amount);
    }

    // Метод для внесения денег на счет
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма для внесения должна быть положительной.");
        
        balance += amount;
        RecordTransaction(amount);
    }

    // Метод для перевода денег с одного счета на другой
    public void Transfer(BankAccount destinationAccount, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма перевода должна быть положительной.");
        if (amount > balance)
            throw new InvalidOperationException("Недостаточно средств на счете.");

        Withdraw(amount);
        destinationAccount.Deposit(amount);
    }

    // Записывает операцию в журнал транзакций
    private void RecordTransaction(decimal amount)
    {
        var transaction = new BankTransaction(amount);
        transactions.Enqueue(transaction);
    }

    // Переопределение оператора == для сравнения счетов
    public static bool operator ==(BankAccount a, BankAccount b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
        return a.accountNumber == b.accountNumber;
    }

    // Переопределение оператора != для сравнения счетов
    public static bool operator !=(BankAccount a, BankAccount b)
    {
        return !(a == b);
    }

    // Переопределение метода Equals для сравнения счетов
    public override bool Equals(object obj)
    {
        if (obj is BankAccount otherAccount)
        {
            return this == otherAccount;
        }
        return false;
    }

    // Переопределение метода GetHashCode
    public override int GetHashCode()
    {
        return accountNumber.GetHashCode();
    }

    // Переопределение ToString для печати информации о счете
    public override string ToString()
    {
        return $"Номер счета: {accountNumber}, Тип: {accountType}, Баланс: {balance:C}, Держатель: {accountHolder}";
    }

    // Индексатор для доступа к транзакциям
    public BankTransaction this[int index]
    {
        get
        {
            if (index < 0 || index >= transactions.Count)
                throw new IndexOutOfRangeException("Неверный индекс транзакции.");
            return (BankTransaction)transactions.ToArray()[index];
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание банковских счетов
        var account1 = new BankAccount(1000, AccountType.Current);
        account1.AccountHolder = "Иванов Иван";

        var account2 = new BankAccount(500, AccountType.Savings);
        account2.AccountHolder = "Петров Петр";

        // Внесение средств на счет
        account1.Deposit(500);
        account2.Deposit(300);

        // Снятие средств с счета
        account1.Withdraw(200);

        // Перевод средств между счетами
        account1.Transfer(account2, 100);

        // Вывод информации о счетах
        Console.WriteLine(account1.ToString());
        Console.WriteLine(account2.ToString());

        // Вывод транзакций
        Console.WriteLine("Транзакции по счету 1:");
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(account1[i].ToString());
        }

        Console.WriteLine("Транзакции по счету 2:");
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine(account2[i].ToString());
        }

        // Сравнение счетов
        Console.WriteLine($"Счет 1 и Счет 2 одинаковы? {account1 == account2}");
    }
}
*/

/*using System;
using System.Collections.Generic;

public class Book
{
    // Поля
    private string title;
    private string author;

    // Конструктор
    public Book(string title, string author)
    {
        this.title = title;
        this.author = author;
    }

    // Свойства с ручными геттерами
    public string Title
    {
        get { return title; }
    }

    public string Author
    {
        get { return author; }
    }

    // Метод для вывода информации о книге
    public void PrintInfo()
    {
        Console.WriteLine($"Название: {title}, Автор: {author}");
    }

    // Метод для изменения названия книги
    public void ChangeTitle(string newTitle)
    {
        this.title = newTitle;
    }

    // Метод для изменения автора книги
    public void ChangeAuthor(string newAuthor)
    {
        this.author = newAuthor;
    }
}

public class Library
{
    // Поле, которое агрегирует множество книг
    private List<Book> books;

    // Конструктор
    public Library()
    {
        books = new List<Book>();
    }

    // Свойства с ручными геттерами
    public List<Book> Books
    {
        get { return books; }
    }

    // Метод для добавления книги в библиотеку
    public void AddBook(Book book)
    {
        books.Add(book);
    }

    // Метод для удаления книги из библиотеки
    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }

    // Метод для вывода информации о всех книгах в библиотеке
    public void DisplayBooks()
    {
        Console.WriteLine("Список книг в библиотеке:");
        foreach (var book in books)
        {
            book.PrintInfo();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем книги
        Book book1 = new Book("1984", "Джордж Оруэлл");
        Book book2 = new Book("Война и мир", "Лев Толстой");

        // Создаем библиотеку
        Library library = new Library();
        
        // Добавляем книги в библиотеку
        library.AddBook(book1);
        library.AddBook(book2);
        
        // Выводим список книг в библиотеке
        library.DisplayBooks();

        // Меняем название книги
        book1.ChangeTitle("Скотный двор");
        library.DisplayBooks();

        // Удаляем книгу из библиотеки
        library.RemoveBook(book1);
        library.DisplayBooks();
    }
}
*/

/*using System;

public class Engine
{
    // Поля
    private string type;
    private int power;

    // Конструктор
    public Engine(string type, int power)
    {
        this.type = type;
        this.power = power;
    }

    // Свойства с ручными геттерами
    public string Type
    {
        get { return type; }
    }

    public int Power
    {
        get { return power; }
    }

    // Метод для включения двигателя
    public void Start()
    {
        Console.WriteLine($"Двигатель типа {type} с мощностью {power} л.с. включен.");
    }

    // Метод для остановки двигателя
    public void Stop()
    {
        Console.WriteLine("Двигатель остановлен.");
    }
}

public class Car
{
    // Поле, которое содержит объект Engine
    private Engine engine;
    private string model;
    private string color;

    // Конструктор
    public Car(string model, string color, string engineType, int enginePower)
    {
        this.model = model;
        this.color = color;
        this.engine = new Engine(engineType, enginePower); // Создание объекта Engine внутри Car
    }

    // Свойства с ручными геттерами
    public string Model
    {
        get { return model; }
    }

    public string Color
    {
        get { return color; }
    }

    // Метод для запуска машины
    public void StartCar()
    {
        Console.WriteLine($"Машина {model} {color} запускается...");
        engine.Start();
    }

    // Метод для остановки машины
    public void StopCar()
    {
        Console.WriteLine($"Машина {model} {color} остановлена.");
        engine.Stop();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем машину с двигателем
        Car car = new Car("Tesla Model S", "Красный", "Электрический", 0);

        // Запускаем и останавливаем машину
        car.StartCar();
        car.StopCar();
    }
}
*/
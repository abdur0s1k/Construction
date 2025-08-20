/*using System;
using System.Collections.Generic;
using System.Linq;

class HockeyPlayer
{
    private string lastName;
    private int age;
    private int gamesPlayed;
    private int missedGoals;

    // Методы для доступа к полям (геттеры и сеттеры)
    public string GetLastName()
    {
        return lastName;
    }

    public void SetLastName(string value)
    {
        lastName = value;
    }

    public int GetAge()
    {
        return age;
    }

    public void SetAge(int value)
    {
        age = value;
    }

    public int GetGamesPlayed()
    {
        return gamesPlayed;
    }

    public void SetGamesPlayed(int value)
    {
        gamesPlayed = value;
    }

    public int GetMissedGoals()
    {
        return missedGoals;
    }

    public void SetMissedGoals(int value)
    {
        missedGoals = value;
    }
}

class Program
{
    static void Main()
    {
        // Создание списка хоккеистов
        List<HockeyPlayer> players = new List<HockeyPlayer>();

        // Заполнение списка
        HockeyPlayer player1 = new HockeyPlayer();
        player1.SetLastName("Иванов");
        player1.SetAge(24);
        player1.SetGamesPlayed(30);
        player1.SetMissedGoals(15);
        players.Add(player1);

        HockeyPlayer player2 = new HockeyPlayer();
        player2.SetLastName("Петров");
        player2.SetAge(26);
        player2.SetGamesPlayed(50);
        player2.SetMissedGoals(20);
        players.Add(player2);

        HockeyPlayer player3 = new HockeyPlayer();
        player3.SetLastName("Сидоров");
        player3.SetAge(28);
        player3.SetGamesPlayed(40);
        player3.SetMissedGoals(10);
        players.Add(player3);

        HockeyPlayer player4 = new HockeyPlayer();
        player4.SetLastName("Кузнецов");
        player4.SetAge(22);
        player4.SetGamesPlayed(35);
        player4.SetMissedGoals(18);
        players.Add(player4);

        // Вычисление среднего возраста хоккеистов
        double averageAge = players.Average(p => p.GetAge());
        Console.WriteLine($"Средний возраст хоккеистов: {averageAge:F2} лет");

        // Вывод информации о хоккеистах старше 25 лет
        Console.WriteLine("\nХоккеисты старше 25 лет:");
        var olderPlayers = players.Where(p => p.GetAge() > 25);

        foreach (var player in olderPlayers)
        {
            Console.WriteLine($"Фамилия: {player.GetLastName()}, Возраст: {player.GetAge()}, Количество игр: {player.GetGamesPlayed()}, Пропущенные шайбы: {player.GetMissedGoals()}");
        }
    }
}

*/

/*using System;
using System.Collections.Generic;
using System.Linq;

class Car
{
    private string brand; // Марка автомобиля
    private string manufacturer; // Производитель
    private double loadCapacity; // Грузоподъемность (в тоннах)
    private int yearOfProduction; // Год выпуска
    private DateTime registrationDate; // Дата регистрации

    // Методы для доступа к полям (геттеры и сеттеры)
    public string GetBrand()
    {
        return brand;
    }

    public void SetBrand(string value)
    {
        brand = value;
    }

    public string GetManufacturer()
    {
        return manufacturer;
    }

    public void SetManufacturer(string value)
    {
        manufacturer = value;
    }

    public double GetLoadCapacity()
    {
        return loadCapacity;
    }

    public void SetLoadCapacity(double value)
    {
        loadCapacity = value;
    }

    public int GetYearOfProduction()
    {
        return yearOfProduction;
    }

    public void SetYearOfProduction(int value)
    {
        yearOfProduction = value;
    }

    public DateTime GetRegistrationDate()
    {
        return registrationDate;
    }

    public void SetRegistrationDate(DateTime value)
    {
        registrationDate = value;
    }
}

class Program
{
    static void Main()
    {
        // Создание списка автомобилей
        List<Car> cars = new List<Car>();

        Car car1 = new Car();
        car1.SetBrand("Volvo FH16");
        car1.SetManufacturer("Volvo");
        car1.SetLoadCapacity(5.0);
        car1.SetYearOfProduction(2018);
        car1.SetRegistrationDate(new DateTime(2021, 6, 15));
        cars.Add(car1);

        Car car2 = new Car();
        car2.SetBrand("MAN TGX");
        car2.SetManufacturer("MAN");
        car2.SetLoadCapacity(3.5);
        car2.SetYearOfProduction(2019);
        car2.SetRegistrationDate(new DateTime(2020, 3, 10));
        cars.Add(car2);

        Car car3 = new Car();
        car3.SetBrand("Kamaz 5490");
        car3.SetManufacturer("Kamaz");
        car3.SetLoadCapacity(2.8);
        car3.SetYearOfProduction(2020);
        car3.SetRegistrationDate(new DateTime(2023, 1, 20));
        cars.Add(car3);

        Car car4 = new Car();
        car4.SetBrand("Scania R500");
        car4.SetManufacturer("Scania");
        car4.SetLoadCapacity(4.5);
        car4.SetYearOfProduction(2017);
        car4.SetRegistrationDate(new DateTime(2019, 12, 5));
        cars.Add(car4);

        // Текущая дата для проверки
        DateTime currentDate = DateTime.Now;

        // Фильтруем автомобили по условиям: зарегистрированы более года назад и грузоподъемность более 3 тонн
        var filteredCars = cars.Where(car =>
            (currentDate - car.GetRegistrationDate()).TotalDays > 365 && car.GetLoadCapacity() > 3.0);

        // Вывод данных
        Console.WriteLine("Автомобили, зарегистрированные более года назад и имеющие грузоподъемность более 3 тонн:");
        foreach (var car in filteredCars)
        {
            Console.WriteLine($"Марка: {car.GetBrand()}, Производитель: {car.GetManufacturer()}, Грузоподъемность: {car.GetLoadCapacity()} т, " +
                              $"Год выпуска: {car.GetYearOfProduction()}, Дата регистрации: {car.GetRegistrationDate():dd.MM.yyyy}");
        }
    }
}

*/

/*using System;
using System.Linq;

struct Marshrut
{
    public int Number;         // Номер маршрута
    public string StartPoint;  // Начальный пункт маршрута
    public string EndPoint;    // Конечный пункт маршрута
    public int Length;         // Длина маршрута
}

class Program
{
    static void Main()
    {
        const int MaxRoutes = 10; // Максимальное количество маршрутов
        Marshrut[] routes = new Marshrut[MaxRoutes];
        int routeCount = 0;

        // Ввод данных о маршрутах
        routeCount = InputRoutes(routes, MaxRoutes);

        // Определение маршрута с максимальной длиной
        FindMaxLengthRoute(routes, routeCount);

        // Сортировка маршрутов по номерам
        SortRoutesByNumber(routes, routeCount);
        Console.WriteLine("\nМаршруты, отсортированные по номерам:");
        PrintRoutes(routes, routeCount);

        // Вывод маршрутов, начинающихся или заканчивающихся в указанном пункте
        Console.Write("\nВведите название пункта: ");
        string point = Console.ReadLine();
        PrintRoutesByPoint(routes, routeCount, point);
    }

    // Ввод данных о маршрутах
    static int InputRoutes(Marshrut[] routes, int maxRoutes)
    {
        int count = 0;

        Console.WriteLine("Введите данные о маршрутах (не более 10 записей):");
        while (count < maxRoutes)
        {
            Console.WriteLine($"\nМаршрут #{count + 1}:");

            Console.Write("Введите номер маршрута: ");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Ошибка ввода номера. Попробуйте снова.");
                continue;
            }

            Console.Write("Введите начальный пункт маршрута: ");
            string startPoint = Console.ReadLine();

            Console.Write("Введите конечный пункт маршрута: ");
            string endPoint = Console.ReadLine();

            Console.Write("Введите длину маршрута: ");
            if (!int.TryParse(Console.ReadLine(), out int length))
            {
                Console.WriteLine("Ошибка ввода длины. Попробуйте снова.");
                continue;
            }

            // Заполнение структуры
            routes[count].Number = number;
            routes[count].StartPoint = startPoint;
            routes[count].EndPoint = endPoint;
            routes[count].Length = length;

            count++;
        }

        return count;
    }

    // Определение маршрута с максимальной длиной
    static void FindMaxLengthRoute(Marshrut[] routes, int routeCount)
    {
        if (routeCount == 0)
        {
            Console.WriteLine("\nНет данных о маршрутах.");
            return;
        }

        Marshrut maxRoute = routes[0];
        for (int i = 1; i < routeCount; i++)
        {
            if (routes[i].Length > maxRoute.Length)
            {
                maxRoute = routes[i];
            }
        }

        Console.WriteLine($"\nМаршрут с максимальной длиной ({maxRoute.Length} км):");
        Console.WriteLine($"Номер: {maxRoute.Number}, Начало: {maxRoute.StartPoint}, Конец: {maxRoute.EndPoint}");
    }

    // Сортировка маршрутов по номерам
    static void SortRoutesByNumber(Marshrut[] routes, int routeCount)
    {
        Array.Sort(routes, 0, routeCount, Comparer<Marshrut>.Create((a, b) => a.Number.CompareTo(b.Number)));
    }

    // Вывод маршрутов, начинающихся или заканчивающихся в указанном пункте
    static void PrintRoutesByPoint(Marshrut[] routes, int routeCount, string point)
    {
        Console.WriteLine($"\nМаршруты, связанные с пунктом '{point}':");

        bool found = false;
        for (int i = 0; i < routeCount; i++)
        {
            if (routes[i].StartPoint.Equals(point, StringComparison.OrdinalIgnoreCase) ||
                routes[i].EndPoint.Equals(point, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Номер: {routes[i].Number}, Начало: {routes[i].StartPoint}, Конец: {routes[i].EndPoint}, Длина: {routes[i].Length}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Нет маршрутов, связанных с данным пунктом.");
        }
    }

    // Вывод всех маршрутов
    static void PrintRoutes(Marshrut[] routes, int routeCount)
    {
        for (int i = 0; i < routeCount; i++)
        {
            Console.WriteLine($"Номер: {routes[i].Number}, Начало: {routes[i].StartPoint}, Конец: {routes[i].EndPoint}, Длина: {routes[i].Length}");
        }
    }
}
*/

/*using System;

class HistoricalDate
{
    // Поля вместо автосвойств
    private int day;
    private int month;
    private int year;
    private int hour;
    private int minute;

    // Методы для установки и получения значений полей
    public void SetDay(int day) => this.day = day;
    public int GetDay() => day;

    public void SetMonth(int month) => this.month = month;
    public int GetMonth() => month;

    public void SetYear(int year) => this.year = year;
    public int GetYear() => year;

    public void SetHour(int hour) => this.hour = hour;
    public int GetHour() => hour;

    public void SetMinute(int minute) => this.minute = minute;
    public int GetMinute() => minute;

    // Метод для вычисления минуты от начала года
    public int CalculateMinuteOfYear()
    {
        DateTime date = new DateTime(year, month, day, hour, minute, 0);
        DateTime startOfYear = new DateTime(year, 1, 1);
        return (int)(date - startOfYear).TotalMinutes;
    }

    // Метод для определения дня недели
    public int GetDayOfWeek()
    {
        DateTime date = new DateTime(year, month, day);
        return (int)date.DayOfWeek == 0 ? 7 : (int)date.DayOfWeek; // 1 — понедельник, 7 — воскресенье
    }
}

class Program
{
    static void Main()
    {
        HistoricalDate historicalDate = new HistoricalDate();

        // Ввод данных
        Console.Write("Введите день (01-31): ");
        historicalDate.SetDay(int.Parse(Console.ReadLine()));

        Console.Write("Введите месяц (01-12): ");
        historicalDate.SetMonth(int.Parse(Console.ReadLine()));

        Console.Write("Введите год (0000-9999): ");
        historicalDate.SetYear(int.Parse(Console.ReadLine()));

        Console.Write("Введите час (0-23): ");
        historicalDate.SetHour(int.Parse(Console.ReadLine()));

        Console.Write("Введите минуту (0-59): ");
        historicalDate.SetMinute(int.Parse(Console.ReadLine()));

        // Форматирование даты
        Console.WriteLine("\nФорматированная дата:");
        Console.WriteLine($"День: {historicalDate.GetDay():D2}");
        Console.WriteLine($"Месяц: {historicalDate.GetMonth():D2}");
        Console.WriteLine($"Год: {historicalDate.GetYear():D4}");

        // Аббревиатура дня недели
        DateTime date = new DateTime(historicalDate.GetYear(), historicalDate.GetMonth(), historicalDate.GetDay());
        string[] dayAbbreviations = { "вс", "пн", "вт", "ср", "чт", "пт", "сб" };
        Console.WriteLine($"День недели (аббревиатура): {dayAbbreviations[(int)date.DayOfWeek]}");

        // Расчёт минуты от начала года
        int minuteOfYear = historicalDate.CalculateMinuteOfYear();
        Console.WriteLine($"\nМинут от начала года: {minuteOfYear}");

        // Определение дня недели
        int dayOfWeek = historicalDate.GetDayOfWeek();
        Console.WriteLine($"День недели (1 — понедельник, 7 — воскресенье): {dayOfWeek}");
    }
}
*/

using System;

struct Channel
{
    private string name;               // Название канала
    private DateTime startTime;        // Время начала профилактических работ
    private DateTime endTime;          // Время окончания профилактических работ

    // Методы для установки и получения данных
    public void SetName(string name) => this.name = name;
    public string GetName() => name;

    public void SetStartTime(DateTime startTime) => this.startTime = startTime;
    public DateTime GetStartTime() => startTime;

    public void SetEndTime(DateTime endTime) => this.endTime = endTime;
    public DateTime GetEndTime() => endTime;

    // Метод для вычисления длительности профилактики в минутах
    public int GetDurationInMinutes()
    {
        return (int)(endTime - startTime).TotalMinutes;
    }

    // Метод для проверки, запланирована ли профилактика на ночное время
    public bool IsNightTime()
    {
        TimeSpan start = startTime.TimeOfDay;
        TimeSpan end = endTime.TimeOfDay;

        return (start >= new TimeSpan(22, 0, 0) || start < new TimeSpan(6, 0, 0)) ||
               (end >= new TimeSpan(22, 0, 0) || end < new TimeSpan(6, 0, 0));
    }
}

class Program
{
    static void Main()
    {
        const int MaxChannels = 5;
        Channel[] channels = new Channel[MaxChannels];
        int channelCount = 0;

        // Ввод данных о каналах
        channelCount = InputChannels(channels, MaxChannels);

        // Вывод информации о профилактике всех каналов
        Console.WriteLine("\nИнформация о профилактике:");
        PrintChannelInfo(channels, channelCount);

        // Вывод информации о ночной профилактике
        Console.WriteLine("\nКаналы с ночной профилактикой:");
        PrintNightChannels(channels, channelCount);
    }

    // Ввод данных о каналах
    static int InputChannels(Channel[] channels, int maxChannels)
    {
        int count = 0;

        Console.WriteLine("Введите данные о каналах (не более 5 записей):");
        while (count < maxChannels)
        {
            Console.WriteLine($"\nКанал #{count + 1}:");

            Console.Write("Введите название канала: ");
            string name = Console.ReadLine();

            Console.Write("Введите дату и время начала профилактики (формат: ГГГГ-ММ-ДД ЧЧ:ММ): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startTime))
            {
                Console.WriteLine("Ошибка ввода времени начала. Попробуйте снова.");
                continue;
            }

            Console.Write("Введите дату и время окончания профилактики (формат: ГГГГ-ММ-ДД ЧЧ:ММ): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime endTime))
            {
                Console.WriteLine("Ошибка ввода времени окончания. Попробуйте снова.");
                continue;
            }

            channels[count] = new Channel();
            channels[count].SetName(name);
            channels[count].SetStartTime(startTime);
            channels[count].SetEndTime(endTime);

            count++;
        }

        return count;
    }

    // Вывод информации о профилактике всех каналов
    static void PrintChannelInfo(Channel[] channels, int channelCount)
    {
        for (int i = 0; i < channelCount; i++)
        {
            Console.WriteLine($"Канал: {channels[i].GetName()}");
            Console.WriteLine($"Начало: {channels[i].GetStartTime():yyyy-MM-dd HH:mm}");
            Console.WriteLine($"Окончание: {channels[i].GetEndTime():yyyy-MM-dd HH:mm}");
            Console.WriteLine($"Длительность: {channels[i].GetDurationInMinutes()} минут\n");
        }
    }

    // Вывод информации о каналах с ночной профилактикой
    static void PrintNightChannels(Channel[] channels, int channelCount)
    {
        bool found = false;

        for (int i = 0; i < channelCount; i++)
        {
            if (channels[i].IsNightTime())
            {
                Console.WriteLine($"Канал: {channels[i].GetName()}");
                Console.WriteLine($"Начало: {channels[i].GetStartTime():yyyy-MM-dd HH:mm}");
                Console.WriteLine($"Окончание: {channels[i].GetEndTime():yyyy-MM-dd HH:mm}");
                Console.WriteLine($"Длительность: {channels[i].GetDurationInMinutes()} минут\n");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Нет каналов с ночной профилактикой.");
        }
    }
}

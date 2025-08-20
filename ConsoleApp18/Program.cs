/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static int N = 10; // Размер поля (размер леса)
    static char[,] forest = new char[N, N]; // Лес представлен в виде двумерного массива
    static Random random = new Random(); // Генератор случайных чисел

    static (int, int) wolf; // Координаты волка
    static List<(int, int)> sheep = new List<(int, int)>(); // Список координат баранов

    static void Main()
    {
        OnWolfEatsSheep += position =>
    Console.WriteLine($"Волк съел барашек в {position}");

        Initialize(); // Инициализация леса, волка и баранов

        while (true)
        {
            Console.Clear(); // Очистка консоли для обновления визуализации
            MoveEntities(); // Перемещение всех сущностей (волк и бараны)
            CheckCollisions(); // Проверка столкновений волка с баранами
            DrawForest(); // Отображение леса в консоли
            Thread.Sleep(500); // Задержка для визуализации (0.5 секунды)
        }
    }


    static void Initialize()
    {
        // Инициализация леса
        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                forest[i, j] = '.'; // Все клетки изначально пустые (обозначаются точкой)

        // Добавление волка на случайную позицию
        wolf = (random.Next(N), random.Next(N));
        forest[wolf.Item1, wolf.Item2] = 'W'; // Обозначение волка символом 'W'

        // Добавление баранов на случайные позиции
        for (int i = 0; i < 3; i++)
        {
            var position = (random.Next(N), random.Next(N));
            // Убедиться, что позиция не совпадает с волком или другими баранами
            while (position == wolf || sheep.Contains(position))
                position = (random.Next(N), random.Next(N));

            sheep.Add(position); // Добавить барана
            forest[position.Item1, position.Item2] = 'S'; // Обозначение барана символом 'S'
        }
    }

    static void MoveEntities()
    {
        // Очистка старых позиций баранов
        foreach (var s in sheep)
            forest[s.Item1, s.Item2] = '.';
        // Очистка старой позиции волка
        forest[wolf.Item1, wolf.Item2] = '.';

        // Движение волка
        wolf = MoveRandomly(wolf);
        forest[wolf.Item1, wolf.Item2] = 'W'; // Обновление позиции волка

        // Движение баранов
        for (int i = 0; i < sheep.Count; i++)
        {
            sheep[i] = MoveRandomly(sheep[i]);
            forest[sheep[i].Item1, sheep[i].Item2] = 'S'; // Обновление позиции барана
        }
    }

    static (int, int) MoveRandomly((int, int) position)
    {
        // Возможные направления движения: -1, 0, 1
        int[] directions = { -1, 0, 1 };
        int dx = directions[random.Next(3)]; // Случайное движение по оси X
        int dy = directions[random.Next(3)]; // Случайное движение по оси Y

        // Новые координаты с учетом выхода за границы (циклическое перемещение)
        int newX = (position.Item1 + dx + N) % N;
        int newY = (position.Item2 + dy + N) % N;

        return (newX, newY); // Возвращаем новые координаты
    }

    public static event Action<(int, int)> OnWolfEatsSheep;

    static void CheckCollisions()
    {
        // Проверка на столкновение волка и баранов
        for (int i = sheep.Count - 1; i >= 0; i--)
        {
            if (sheep[i] == wolf)
            {
                OnWolfEatsSheep?.Invoke(sheep[i]); // Вызываем событие
                sheep.RemoveAt(i);
            }
        }

        // Проверка на совпадение баранов (рождение нового барана)
        var newSheep = new List<(int, int)>();
        for (int i = 0; i < sheep.Count; i++)
        {
            for (int j = i + 1; j < sheep.Count; j++)
            {
                if (sheep[i] == sheep[j]) // Если два барана находятся на одной клетке
                {
                    var position = (random.Next(N), random.Next(N));
                    // Генерация новой позиции для нового барана
                    while (forest[position.Item1, position.Item2] != '.')
                        position = (random.Next(N), random.Next(N));

                    newSheep.Add(position); // Добавляем нового барана в список
                }
            }
        }
        sheep.AddRange(newSheep); // Добавляем всех новых баранов к основному списку
    }

    static void DrawForest()
    {
        // Отображение леса построчно
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(forest[i, j] + " "); // Вывод символов с пробелом
            }
            Console.WriteLine(); // Переход на новую строку
        }
    }

}
*/

/*using System;
using System.Collections.Generic;

class Roulette
{
    static Random random = new Random();

    // Событие, которое будет срабатывать при выигрыше игрока
    public static event Action<int> PlayerWon;

    // Генерация случайного сектора рулетки
    static int GenerateBall()
    {
        return random.Next(0, 37); // 0-36
    }

    // Определение цвета сектора по его номеру
    static string DetermineColor(int number)
    {
        if (number == 0) return "Зелёный";
        else if (number % 2 == 0)
        {
            if (Array.Exists(new int[] { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 }, n => n == number))
                return "Чёрный";
            else
                return "Красный";
        }
        else
        {
            if (Array.Exists(new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 }, n => n == number))
                return "Красный";
            else
                return "Чёрный";
        }
    }

    // Запрос ставки у игрока
    static (string, string) GetBet()
    {
        Console.WriteLine("Сделайте ставку:");
        Console.WriteLine("1. На цвет (красное/чёрное)");
        Console.WriteLine("2. На чётное или нечётное");
        Console.WriteLine("3. На диапазон (1-18 или 19-36)");
        Console.WriteLine("4. На конкретное число");
        string betType = Console.ReadLine();
        Console.Write("Введите вашу ставку: ");
        string betValue = Console.ReadLine();
        return (betType, betValue);
    }

    // Проверка выигрыша игрока по ставке
    static bool CheckWinner(string betType, string betValue, int number, string color, int playerIndex)
    {
        bool isWinner = false;

        if (betType == "1")
        {
            isWinner = betValue.ToLower() == color.ToLower();
        }
        else if (betType == "2")
        {
            isWinner = (betValue.ToLower() == "чётное" && number % 2 == 0) || (betValue.ToLower() == "нечётное" && number % 2 != 0);
        }
        else if (betType == "3")
        {
            isWinner = (betValue == "1-18" && number >= 1 && number <= 18) || (betValue == "19-36" && number >= 19 && number <= 36);
        }
        else if (betType == "4")
        {
            isWinner = betValue == number.ToString();
        }

        // Если игрок выиграл, вызываем событие
        if (isWinner)
        {
            PlayerWon?.Invoke(playerIndex); // Вызов события
        }

        return isWinner;
    }

    // Основной игровой процесс
    static void PlayGame()
    {
        Console.WriteLine("Добро пожаловать в рулетку!");
        Console.Write("Введите количество игроков (1-3): ");
        int numPlayers = int.Parse(Console.ReadLine());

        if (numPlayers < 1 || numPlayers > 3)
        {
            Console.WriteLine("Неверное количество игроков!");
            return;
        }

        // Список для хранения ставок игроков
        List<(string, string)> playersBets = new List<(string, string)>();

        // Запрос ставок у каждого игрока
        for (int i = 0; i < numPlayers; i++)
        {
            Console.WriteLine($"\nИгрок {i + 1}:");
            var bet = GetBet(); // Запрашиваем ставку
            playersBets.Add(bet); // Добавляем ставку в список
        }

        // Генерация случайного числа и определение его цвета
        int number = GenerateBall();
        string color = DetermineColor(number);

        // Вывод результата о выпавшем числе и его цвете
        Console.WriteLine($"\nВыпал номер {number}, цвет: {color}");

        // Подписка на событие
        PlayerWon += (playerIndex) =>
        {
            Console.WriteLine($"Игрок {playerIndex + 1} выиграл!");
        };

        // Проверка ставок и вывод информации о выигрыше
        for (int i = 0; i < playersBets.Count; i++)
        {
            var (betType, betValue) = playersBets[i]; // Получаем ставку игрока
            bool isWinner = CheckWinner(betType, betValue, number, color, i);
            if (!isWinner)
            {
                Console.WriteLine($"Игрок {i + 1} не выиграл."); // Если ставка не сыграла
            }
        }
    }

    // Главный метод программы
    static void Main()
    {
        PlayGame(); // Запуск игры
    }
}
*/

using System;

class НовостнойОператор
{
    // Определение события, которое срабатывает при выходе новой новости
    public event EventHandler<НовостьEventArgs> НоваяНовость;

    // Метод для рассылки новости
    public void ОтправитьНовость(string категория, string сообщение)
    {
        // Создание нового события и его вызов
        НовостьEventArgs новость = new НовостьEventArgs(категория, сообщение);
        OnНоваяНовость(новость);
    }

    // Вспомогательный метод для вызова события
    protected virtual void OnНоваяНовость(НовостьEventArgs e)
    {
        // Вызов события, если подписчики есть
        НоваяНовость?.Invoke(this, e);
    }
}

public class НовостьEventArgs : EventArgs
{
    // Категория новости (например, "погода", "спорт", "новости" и т.д.)
    public string Категория { get; }
    // Сообщение новости
    public string Сообщение { get; }

    public НовостьEventArgs(string категория, string сообщение)
    {
        Категория = категория;
        Сообщение = сообщение;
    }
}

class ПодписчикУслуги
{
    // Название категории, на которую подписан подписчик
    public string Категория { get; }
    // Имя подписчика
    public string Имя { get; }

    public ПодписчикУслуги(string имя, string категория)
    {
        Имя = имя;
        Категория = категория;
    }

    // Обработчик события, который срабатывает, когда приходит новость
    public void ПолучитьНовость(object sender, НовостьEventArgs e)
    {
        // Если категория совпадает с тем, на что подписан подписчик
        if (e.Категория == Категория)
        {
            Console.WriteLine($"{Имя} получил новость в категории {e.Категория}: {e.Сообщение}");
        }
    }
}

class Программа
{
    static void Main()
    {
        // Создаем новостного оператора
        НовостнойОператор оператор = new НовостнойОператор();

        // Создаем подписчиков на разные категории
        ПодписчикУслуги подписчик1 = new ПодписчикУслуги("Иван", "погода");
        ПодписчикУслуги подписчик3 = new ПодписчикУслуги("Петр", "новости");

        // Подписываем подписчиков на новости
        оператор.НоваяНовость += подписчик1.ПолучитьНовость;
        оператор.НоваяНовость += подписчик3.ПолучитьНовость;

        // Отправляем новости
        оператор.ОтправитьНовость("погода", "Сегодня солнечно.");
        оператор.ОтправитьНовость("спорт", "Команда выиграла матч.");
        оператор.ОтправитьНовость("новости", "Вышел новый закон.");

        // Отписка от новостей по категории
        оператор.НоваяНовость -= подписчик1.ПолучитьНовость;

        // Отправляем еще одну новость
        оператор.ОтправитьНовость("погода", "Ожидаются дожди.");
    }
}





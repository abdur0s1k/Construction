using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

// Делегаты для событий
public delegate void ArtifactUsedEventHandler(RPGCharacter character, IUsable artifact);
public delegate void HealthChangedEventHandler(RPGCharacter character, int healthChange);
public delegate void StateChangedEventHandler(RPGCharacter character, string newState);
public delegate void SpellCastEventHandler(RPGCharacter caster, RPGCharacter target, Spell spell);

// Интерфейс для использования артефактов
public interface IUsable
{
    void Use(RPGCharacter character); // Метод использования артефакта
    string GetItemName();
}

// Класс персонажа RPG
public class RPGCharacter : IComparable<RPGCharacter>
{
    // События
    public event ArtifactUsedEventHandler ArtifactUsed;
    public event HealthChangedEventHandler HealthChanged;
    public event StateChangedEventHandler StateChanged;
    public event SpellCastEventHandler SpellCast;

    private static int nextId = 1; // Статический счётчик для ID персонажей
    private int id; // Уникальный идентификатор персонажа
    private string name; // Имя персонажа
    private string race; // Раса персонажа
    private string gender; // Пол персонажа
    private string state; // Состояние персонажа
    private bool canTalk; // Можем ли мы говорить
    private bool canMove; // Можем ли мы двигаться
    private int age; // Возраст персонажа
    private int health; // Текущее здоровье
    private int maxHealth; // Максимальное здоровье
    private int experience; // Опыт персонажа
    private List<IUsable> inventory; // Инвентарь (артефакты)
    private List<Spell> learnedSpells; // Список выученных заклинаний

    public List<IUsable> Inventory
    {
        get { return inventory; }
    }

    public int Id { get { return id; } }
    public string Name { get { return name; } }
    public string Race { get { return race; } }
    public string Gender { get { return gender; } }
    public string State
    {
        get { return state; }
        set
        {
            state = value;
            StateChanged?.Invoke(this, value); // Вызываем событие при изменении состояния
        }
    }
    public bool CanTalk { get { return canTalk; } set { canTalk = value; } }
    public bool CanMove { get { return canMove; } set { canMove = value; } }
    public int Age { get { return age; } set { age = value; } }
    public int Health
    {
        get { return health; }
        set
        {
            health = Math.Max(0, value);
            HealthChanged?.Invoke(this, health); // Вызываем событие при изменении здоровья
        }
    }
    public int MaxHealth { get { return maxHealth; } }
    public int Experience { get { return experience; } set { experience = value; } }

    // Пропорция здоровья
    private double HealthPercent => (double)Health / MaxHealth * 100;

    public RPGCharacter(string name, string race, string gender, int maxHealth, int age)
    {
        id = nextId++; // Присваиваем уникальный ID
        this.name = name;
        this.race = race;
        this.gender = gender;
        this.maxHealth = maxHealth;
        this.age = age;
        this.health = maxHealth;
        this.state = "Нормальное";
        this.canTalk = true;
        this.canMove = true;
        this.experience = 0;
        this.inventory = new List<IUsable>();
        this.learnedSpells = new List<Spell>();
    }

    // Метод сравнения для сортировки по опыту
    public int CompareTo(RPGCharacter other)
    {
        return Experience.CompareTo(other.Experience);
    }

    // Метод для отображения информации о персонаже
    public override string ToString()
    {
        return $"ID: {Id}, Имя: {Name}, Раса: {Race}, Пол: {Gender}, Состояние: {State}, Здоровье: {Health}/{MaxHealth}, Опыт: {Experience}";
    }

    // Метод для добавления артефакта в инвентарь
    public void PickupArtifact(IUsable artifact)
    {
        inventory.Add(artifact);
        Console.WriteLine($"{Name} подобрал артефакт.");
    }

    // Метод для выбрасывания артефакта из инвентаря
    public void DropArtifact(IUsable artifact)
    {
        if (inventory.Contains(artifact))
        {
            inventory.Remove(artifact);
            Console.WriteLine($"{Name} выбросил артефакт.");
        }
        else
        {
            Console.WriteLine($"{Name} не имеет этого артефакта в инвентаре.");
        }
    }

    // Метод для передачи артефакта другому персонажу
    public void TransferArtifact(RPGCharacter recipient, IUsable artifact)
    {
        if (inventory.Contains(artifact))
        {
            inventory.Remove(artifact);
            recipient.PickupArtifact(artifact);
            Console.WriteLine($"{Name} передал артефакт персонажу {recipient.Name}.");
        }
        else
        {
            Console.WriteLine($"{Name} не имеет этого артефакта в инвентаре.");
        }
    }

    // Метод для использования артефакта
    public void UseArtifact(IUsable artifact)
    {
        if (inventory.Contains(artifact))
        {
            artifact.Use(this);
            ArtifactUsed?.Invoke(this, artifact); // Вызываем событие артефакта
            inventory.Remove(artifact); // Убираем артефакт из инвентаря, если он использован
        }
        else
        {
            Console.WriteLine($"{Name} не имеет этого артефакта в инвентаре.");
        }
    }

    public void EarnExperience(int points)
    {
        Experience += points;
        Console.WriteLine($"{Name} заработал {points} опыта. Общий опыт: {Experience}");
    }

    // Метод для выучивания заклинания
    public void LearnSpell(Spell spell)
    {
        if (learnedSpells.Contains(spell))
        {
            Console.WriteLine($"{Name} уже выучил заклинание {spell.Name}.");
        }
        else
        {
            learnedSpells.Add(spell);
            Console.WriteLine($"{Name} выучил заклинание {spell.Name}.");
        }
    }

    // Метод для забывания заклинания
    public void ForgetSpell(Spell spell)
    {
        if (learnedSpells.Contains(spell))
        {
            learnedSpells.Remove(spell);
            Console.WriteLine($"{Name} забыл заклинание {spell.Name}.");
        }
        else
        {
            Console.WriteLine($"{Name} не знает этого заклинания.");
        }
    }

    // Метод для произнесения заклинания
    public void CastSpell(Spell spell, RPGCharacter target, int power = 0)
    {
        if (learnedSpells.Contains(spell))
        {
            spell.CastSpell(target, power);
            SpellCast?.Invoke(this, target, spell); // Вызываем событие при использовании заклинания
        }
        else
        {
            Console.WriteLine($"{Name} не знает заклинания {spell.Name}.");
        }
    }
}

// Абстрактный класс заклинания
public abstract class Spell
{
    private string name;
    private int power;

    public string Name { get { return name; } set { name = value; } }
    public int Power { get { return power; } set { power = value; } }

    public abstract void CastSpell(RPGCharacter target, int power = 0);
}

// Пример заклинания исцеления
public class HealingSpell : Spell
{
    public HealingSpell(int power)
    {
        Name = "Исцеление";
        Power = power;
    }

    public override void CastSpell(RPGCharacter target, int power = 0)
    {
        int healingAmount = Math.Min(Power + power, target.MaxHealth - target.Health);
        target.Health += healingAmount;
        Console.WriteLine($"{target.Name} исцелен на {healingAmount} единиц здоровья с помощью заклинания {Name}.");
    }
}

// Пример заклинания огненного удара
public class FireballSpell : Spell
{
    public FireballSpell(int power = 10) // Используем значение по умолчанию
    {
        Name = "Огненный шар";
        Power = power;
    }


    public override void CastSpell(RPGCharacter target, int power = 0)
    {
        int damage = Power + power;
        target.Health -= damage;
        if (target.Health <= 0)
        {
            target.State = "Мёртв";
            Console.WriteLine($"{target.Name} погиб от Огненного шара!");
        }
        else
        {
            Console.WriteLine($"{target.Name} получил {damage} урона от заклинания {Name}. Здоровье: {target.Health}");
        }
    }
}



// Новый класс для заклинания антидота
public class AntidoteSpell : Spell
{
    public AntidoteSpell()
    {
        Name = "Антидот";
        Power = 0;
    }

    public override void CastSpell(RPGCharacter target, int power = 0)
    {
        if (target.State == "Отравлен")
        {
            target.State = "Здоров";
            Console.WriteLine($"{target.Name} излечен от отравления с помощью заклинания {Name}.");
        }
        else
        {
            Console.WriteLine($"{target.Name} не отравлен.");
        }
    }
}

// Новый класс для заклинания воскрешения
public class ReviveSpell : Spell
{
    public ReviveSpell()
    {
        Name = "Воскрешение";
        Power = 0;
    }

    public override void CastSpell(RPGCharacter target, int power = 0)
    {
        if (target.State == "Мёртв")
        {
            target.Health = target.MaxHealth / 2;
            target.State = "Здоров";
            Console.WriteLine($"{target.Name} был воскрешён с помощью заклинания {Name}.");
        }
        else
        {
            Console.WriteLine($"{target.Name} не мёртв.");
        }
    }
}

// Класс артефакта
public class LifeWaterBottle : IUsable
{
    private int power;

    public string GetItemName()
    {
        return $"Бутылка с живой водой (50 здоровья)";
    }

    public LifeWaterBottle(int power)
    {
        this.power = power;
    }

    public void Use(RPGCharacter character)
    {
        int healingAmount = Math.Min(power, character.MaxHealth - character.Health);
        character.Health += healingAmount;
        Console.WriteLine($"{character.Name} исцелен на {healingAmount} единиц здоровья с помощью Бутылки с Живой Водой.");
    }
}

// Класс ядовитой слюны (артефакт)
public class PoisonSaliva : IUsable
{
    private int power;

    public PoisonSaliva(int power)
    {
        this.power = power;
    }

    public string GetItemName()
    {
        return $"Яд (20 урона)";
    }
    public void Use(RPGCharacter character)
    {
        if (character.State != "Здоров")
        {
            character.Health -= power;
            if (character.Health <= 0)
            {
                character.State = "Мёртв";
                Console.WriteLine($"{character.Name} погиб от отравления!");
            }
            else
            {
                character.State = "Отравлен";
                Console.WriteLine($"{character.Name} отравлен! Потеряно {power} единиц здоровья.");
            }
        }
    }
}

// Основной класс для запуска игры
class Program
{
    static void Main()
    {
        // История игры
        Console.WriteLine("Мир в опасности. Тёмный маг вернулся, и его армия разрушает деревни.");
        Console.WriteLine("Ты — герой, способный изменить судьбу этого мира. Выбирай свою судьбу.");

        // Выбор персонажа
        RPGCharacter character = CreateCharacter();

        // Проверка на смерть сразу после создания персонажа
        if (character.State == "Мёртв")
        {
            Console.WriteLine($"{character.Name} мертв. Игра завершена.");
            return;
        }

        // Введение в игру
        Console.WriteLine("\nПутешествие начинается...");
        Console.WriteLine("Вы находитесь в маленькой деревне, окружённой лесами и горами. Местные жители обеспокоены нападениями тёмных существ.");

        // Первое задание
        Console.WriteLine("\nЗадание 1: Защитить деревню от нападения!");
        Console.WriteLine("Деревня находится под угрозой. Тёмные твари, принадлежащие армии магов, приближаются. Ваши действия?");
        Console.WriteLine("1. Принять бой и попытаться победить");
        Console.WriteLine("2. Собрать местных жителей и эвакуировать их в безопасное место");
        int choice1 = GetChoice();

        if (choice1 == 1)
        {
            Console.WriteLine("\nВы приняли бой с тёмными тварями. Битва была трудной, но вы смогли победить.");
            TakeDamage(character); // Персонаж получил урон в бою
            if (character.State == "Мёртв") return; // Проверка смерти после получения урона

            DropItem(character); // Враги могут уронить предметы
            UseItemDuringBattle(character); // Использование предметов в бою
            UseSpellsDuringBattle(character); // Использование заклинаний в бою
            character.EarnExperience(100); // Добавление опыта
            Console.WriteLine("Местные жители благодарны за вашу храбрость. Однако, маги по-прежнему угрожают всему королевству.");
        }
        else
        {
            Console.WriteLine("\nВы решили эвакуировать людей. Это позволило сохранить жизнь многим, но тёмные твари продолжили свои атаки.");
            character.EarnExperience(50); // Добавление опыта за эвакуацию
            Console.WriteLine("Маги начинают захватывать новые территории, и вам нужно отправиться в следующее королевство.");
        }

        // Проверка состояния персонажа
        Console.WriteLine($"\nСостояние персонажа: {character.State}, Здоровье: {character.Health}/{character.MaxHealth}");
        if (character.State == "Мёртв")
        {
            Console.WriteLine($"{character.Name} мертв. Игра завершена.");
            return;
        }

        // Вторая задача
        Console.WriteLine("\nЗадание 2: Найти союзников");
        Console.WriteLine("Вам нужно найти способ остановить тёмного мага. Для этого нужно найти древний артефакт, который может повергнуть его.");
        Console.WriteLine("Однако, артефакт охраняется могущественным драконом. Что вы будете делать?");
        Console.WriteLine("1. Пройти через опасные леса и найти способ победить дракона");
        Console.WriteLine("2. Попытаться заключить союз с могущественным колдуном в соседнем королевстве");

        int choice2 = GetChoice();
        if (choice2 == 1)
        {
            Console.WriteLine("\nВы отправились через леса. Бой с драконом оказался долгим и сложным, но вам удалось одержать победу.");
            TakeDamage(character); // Персонаж получил урон от дракона
            if (character.State == "Мёртв") return; // Проверка смерти после получения урона

            DropItem(character); // Дракон уронил предмет
            UseItemDuringBattle(character); // Использование предметов в бою
            UseSpellsDuringBattle(character); // Использование заклинаний в бою
            character.EarnExperience(200); // Добавление опыта за победу
            Console.WriteLine("Вы нашли древний артефакт, который позволяет ослабить тёмного мага. Теперь вам предстоит встретиться с ним лицом к лицу.");
        }
        else
        {
            Console.WriteLine("\nВы решили обратиться за помощью к могущественному колдуну. Он согласился помочь, но только если вы выполните его задание.");
            character.EarnExperience(150); // Добавление опыта за решение искать союз
            Console.WriteLine("Теперь вы должны найти редкое растение в лесу, чтобы создать зелье для колдуна.");
        }

        // Проверка состояния персонажа
        Console.WriteLine($"\nСостояние персонажа: {character.State}, Здоровье: {character.Health}/{character.MaxHealth}");
        if (character.State == "Мёртв")
        {
            Console.WriteLine($"{character.Name} мертв. Игра завершена.");
            return;
        }

        // Третья задача
        Console.WriteLine("\nЗадание 3: Встреча с тёмным магом");
        Console.WriteLine("Наконец, вы дошли до замка тёмного мага. Он ждал вас. Ваша встреча будет решающей!");
        Console.WriteLine("1. Напасть на мага, используя артефакт и заклинания");
        Console.WriteLine("2. Попытаться договориться с магом и узнать его мотивы");

        int choice3 = GetChoice();
        if (choice3 == 1)
        {
            Console.WriteLine("\nВы решили атаковать. Битва была жестокой, но благодаря артефакту и заклинаниям, вы победили мага.");
            TakeDamage(character); // Персонаж получил урон от мага
            if (character.State == "Мёртв") return; // Проверка смерти после получения урона

            DropItem(character); // Маг может уронить предмет
            UseItemDuringBattle(character); // Использование предметов в бою
            UseSpellsDuringBattle(character); // Использование заклинаний в бою
            character.EarnExperience(500); // Добавление опыта за победу над магом
            Console.WriteLine("Мир спасён, и вы стали легендой.");
        }
        else
        {
            Console.WriteLine("\nВы решили поговорить с магом. Он рассказал вам, что его мотивы связаны с поисками бессмертия и власти.");
            Console.WriteLine("Вы предложили ему альтернативный путь, и он согласился отступить. Мир был спасён, но ценой мира стало много жертв.");
            character.EarnExperience(300); // Добавление опыта за мирное решение
        }
        Console.WriteLine($"\nСостояние персонажа: {character.State}, Здоровье: {character.Health}/{character.MaxHealth}");
        if (character.State == "Мёртв")
        {
            Console.WriteLine($"{character.Name} мертв. Игра завершена.");
            return;
        }
        // Заключение
        Console.WriteLine("\nВаше путешествие завершилось. Но каждый выбор, который вы сделали, повлиял на исход истории.");
        Console.WriteLine("Спасибо за участие! Путешествие продолжается...");
    }



    static RPGCharacter CreateCharacter()
    {
        Console.WriteLine("1. Создать воина");
        Console.WriteLine("2. Создать мага");
        Console.Write("Выбор: ");
        int choice = int.Parse(Console.ReadLine());

        RPGCharacter character = null;

        // Создание воина
        if (choice == 1)
        {
            Console.Write("Введите имя воина: ");
            string name = Console.ReadLine();
            Console.Write("Введите расу (Человек, Гном, Эльф): ");
            string race = Console.ReadLine();
            Console.Write("Введите пол: ");
            string gender = Console.ReadLine();
            Console.Write("Введите максимальное здоровье: ");
            int maxHealth = int.Parse(Console.ReadLine());
            Console.Write("Введите возраст: ");
            int age = int.Parse(Console.ReadLine());

            character = new RPGCharacter(name, race, gender, maxHealth, age);
            Console.WriteLine($"Вы создали персонажа:\n{character.ToString()}");
        }
        // Создание мага
        else if (choice == 2)
        {
            Console.Write("Введите имя мага: ");
            string name = Console.ReadLine();
            Console.Write("Введите расу (Человек, Гном, Эльф): ");
            string race = Console.ReadLine();
            Console.Write("Введите пол: ");
            string gender = Console.ReadLine();
            Console.Write("Введите максимальное здоровье: ");
            int maxHealth = int.Parse(Console.ReadLine());
            Console.Write("Введите возраст: ");
            int age = int.Parse(Console.ReadLine());

            character = new RPGCharacter(name, race, gender, maxHealth, age);
            Console.WriteLine($"Вы создали персонажа:\n{character.ToString()}");
        }
        // Выбор неправильного варианта
        else
        {
            Console.WriteLine("Неверный выбор.");
            return null;
        }

        return character;
    }

    static void TakeDamage(RPGCharacter character)
    {
        // Персонаж получает урон
        Random rand = new Random();
        int damage = rand.Next(10, 30); // Урон от врага
        character.Health -= damage;
        Console.WriteLine($"\nВы получили {damage} урона. Текущее здоровье: {character.Health}/{character.MaxHealth}");

        if (character.Health <= 0)
        {
            character.State = "Мёртв";
            Console.WriteLine($"{character.Name} погиб...");
        }
    }


    static void DropItem(RPGCharacter character)
    {
        // Враги или боссы могут уронить предметы
        Console.WriteLine("\nВраг был побеждён, и он уронил артефакт!");

        // Дроп различных артефактов в зависимости от задания
        Random rand = new Random();
        int randomDrop = rand.Next(1, 2);

        IUsable item = null;
        switch (randomDrop)
        {
            case 1:
                item = new LifeWaterBottle(50); // Пример дропа - бутылка с живой водой
                Console.WriteLine("Враг уронил: Бутылка с живой водой (50 здоровья)");
                break;
            case 2:
                item = new PoisonSaliva(20); // Пример дропа - яд
                Console.WriteLine("Враг уронил: Яд (20 урона)");
                break;
        }

        character.PickupArtifact(item); // Добавляем предмет в инвентарь
    }


    static void UseItemDuringBattle(RPGCharacter character)
    {
        // Использование предметов в бою
        Console.WriteLine("\nВ процессе боя вы решаете использовать артефакт из инвентаря.");

        // Проверяем, есть ли предметы в инвентаре
        if (character.Inventory.Count > 0)
        {
            Console.WriteLine("Ваш инвентарь:");

            // Перечисляем все артефакты в инвентаре
            for (int i = 0; i < character.Inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {character.Inventory[i].GetItemName()}");
            }

            // Запросить выбор артефакта
            Console.Write("Выберите артефакт для использования (номер) или введите 0 для отмены: ");
            int choice = int.Parse(Console.ReadLine()) - 1;

            // Если пользователь выбрал 0, отменяем использование артефакта
            if (choice == -1)
            {
                Console.WriteLine("Вы отменили использование артефакта.");
            }
            // Проверяем, что выбранный артефакт существует
            else if (choice >= 0 && choice < character.Inventory.Count)
            {
                IUsable item = character.Inventory[choice];
                character.UseArtifact(item); // Используем выбранный артефакт
                Console.WriteLine($"Вы использовали {item.GetItemName()}.");
            }
            else
            {
                Console.WriteLine("Некорректный выбор.");
            }
        }
        else
        {
            Console.WriteLine("В вашем инвентаре нет артефактов.");
        }
    }



    static void UseSpellsDuringBattle(RPGCharacter character)
    {
        // Использование заклинаний в бою
        Console.WriteLine("\nВ процессе боя вы решаете использовать заклинание.");

        // Если персонаж - воин
        if (character is RPGCharacter warrior)
        {
            Console.WriteLine("Доступные заклинания для воина:");
            Console.WriteLine("1. Исцеление");
            Console.WriteLine("2. Огненный шар");
            Console.WriteLine("3. Антидот");
            Console.Write("Выберите заклинание для использования (1-3): ");
            int choice = int.Parse(Console.ReadLine());

            // Логика выбора заклинания
            switch (choice)
            {
                case 1:
                    HealingSpell healingSpell = new HealingSpell(30);
                    warrior.LearnSpell(healingSpell);
                    warrior.CastSpell(healingSpell, warrior); // Использование заклинания исцеления
                    break;
                case 2:
                    FireballSpell fireballSpell = new FireballSpell(50);
                    warrior.LearnSpell(fireballSpell);
                    warrior.CastSpell(fireballSpell, warrior); // Использование заклинания огненного шара
                    break;
                case 3:
                    AntidoteSpell antidoteSpell = new AntidoteSpell();
                    warrior.LearnSpell(antidoteSpell);
                    warrior.CastSpell(antidoteSpell, warrior); // Использование заклинания отравления
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }
        // Если персонаж - маг
        else if (character is RPGCharacter magician)
        {
            Console.WriteLine("Доступные заклинания для мага:");
            Console.WriteLine("1. Исцеление");
            Console.WriteLine("2. Огненный шар");
            Console.WriteLine("3. Антидот");
            Console.Write("Выберите заклинание для использования (1-3): ");
            int choice = int.Parse(Console.ReadLine());

            // Логика выбора заклинания
            switch (choice)
            {
                case 1:
                    HealingSpell healingSpell = new HealingSpell(30);
                    magician.LearnSpell(healingSpell);
                    magician.CastSpell(healingSpell, magician); // Использование заклинания исцеления
                    break;
                case 2:
                    FireballSpell fireballSpell = new FireballSpell(50);
                    magician.LearnSpell(fireballSpell);
                    magician.CastSpell(fireballSpell, magician); // Использование заклинания огненного шара
                    break;
                case 3:
                    AntidoteSpell antidoteSpell = new AntidoteSpell();
                    magician.LearnSpell(antidoteSpell);
                    magician.CastSpell(antidoteSpell, magician); // Использование заклинания отравления
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Этот персонаж не может использовать заклинания.");
        }
    }



    static int GetChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
        {
            Console.WriteLine("Пожалуйста, введите корректный номер (1 или 2).");
        }
        return choice;
    }
}

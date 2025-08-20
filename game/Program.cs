using System;
using System.Collections.Generic;

public enum State
{
    Normal,
    Weakened,
    Sick,
    Poisoned,
    Paralyzed,
    Dead
}

public enum Race
{
    Human,
    Dwarf,
    Elf,
    Orc,
    Goblin
}

public class RPGCharacter : IComparable<RPGCharacter>
{
    private static int _idCounter = 1;

    // Поля
    private int _id;
    private string _name;
    private Race _characterRace;
    private string _gender;
    private int _age;
    private State _currentState;
    private bool _canSpeak;
    private bool _canMove;
    private int _currentHealth;
    private int _maxHealth;
    private int _experience;

    // Свойства
    public int Id => _id;
    public string Name => _name;
    public Race CharacterRace => _characterRace;
    public string Gender => _gender;
    public int Age => _age;

    // Для чтения состояния
    public State CurrentState => _currentState;

    // Для записи состояния
    public void SetCurrentState(State state) => _currentState = state;

    // Свойства для здоровья
    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = Math.Max(0, value);
            UpdateState(); // Обновляем состояние при изменении здоровья
        }
    }

    public int MaxHealth => _maxHealth;
    public int Experience
    {
        get => _experience;
        set => _experience = value;
    }

    // Конструктор
    public RPGCharacter(string name, Race race, string gender, int age, int maxHealth)
    {
        _id = _idCounter++;
        _name = name;
        _characterRace = race;
        _gender = gender;
        _age = age;
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
        _currentState = State.Normal;
        _canSpeak = true;
        _canMove = true;
        _experience = 0;
    }

    // Метод для обновления состояния
    private void UpdateState()
    {
        if (_currentHealth == 0)
        {
            _currentState = State.Dead;
            _canSpeak = false;
            _canMove = false;
        }
        else if ((double)_currentHealth / _maxHealth < 0.1)
        {
            _currentState = State.Weakened;
        }
        else
        {
            _currentState = State.Normal;
        }
    }

    // Реализация интерфейса IComparable
    public int CompareTo(RPGCharacter other)
    {
        return _experience.CompareTo(other.Experience);
    }

    // Переопределение ToString
    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Race: {CharacterRace}, Gender: {Gender}, " +
               $"Age: {Age}, Health: {CurrentHealth}/{MaxHealth}, State: {CurrentState}, " +
               $"Experience: {Experience}";
    }
}

public class MagicCharacter : RPGCharacter
{
    // Поля для маны
    private int _currentMana;
    private int _maxMana;

    // Свойства для маны
    public int CurrentMana
    {
        get => _currentMana;
        set => _currentMana = Math.Max(0, value);
    }

    public int MaxMana => _maxMana;

    // Конструктор
    public MagicCharacter(string name, Race race, string gender, int age, int maxHealth, int maxMana)
        : base(name, race, gender, age, maxHealth)
    {
        _maxMana = maxMana;
        _currentMana = maxMana;
    }

    // Метод для лечения
    public void CastHeal(RPGCharacter target, int power)
    {
        int requiredMana = power * 2;
        if (_currentMana < requiredMana)
        {
            Console.WriteLine("Not enough mana to cast heal.");
            return;
        }

        int healthToAdd = Math.Min(power, target.MaxHealth - target.CurrentHealth);
        target.CurrentHealth += healthToAdd;
        _currentMana -= healthToAdd * 2;
        Console.WriteLine($"{Name} healed {target.Name} by {healthToAdd} health points.");
    }
}

public interface IMagic
{
    void CastSpell(RPGCharacter target, int power = 0);
}

public abstract class Spell : IMagic
{
    // Поля
    private int _minMana;
    private bool _hasVerbalComponent;
    private bool _hasMotorComponent;

    // Свойства
    public int MinMana => _minMana;
    public bool HasVerbalComponent => _hasVerbalComponent;
    public bool HasMotorComponent => _hasMotorComponent;

    // Конструктор
    protected Spell(int minMana, bool verbal, bool motor)
    {
        _minMana = minMana;
        _hasVerbalComponent = verbal;
        _hasMotorComponent = motor;
    }

    // Абстрактный метод для кастования заклинания
    public abstract void CastSpell(RPGCharacter target, int power = 0);
}

public class HealSpell : Spell
{
    // Конструктор
    public HealSpell() : base(0, true, false) { }

    // Реализация кастования заклинания Heal
    public override void CastSpell(RPGCharacter target, int power = 0)
    {
        if (target is MagicCharacter caster)
        {
            int requiredMana = power * 2;
            if (caster.CurrentMana < requiredMana)
            {
                Console.WriteLine("Not enough mana for Heal Spell.");
                return;
            }

            int healthToAdd = Math.Min(power, target.MaxHealth - target.CurrentHealth);
            target.CurrentHealth += healthToAdd;
            caster.CurrentMana -= requiredMana;
            Console.WriteLine($"Heal Spell restored {healthToAdd} health to {target.Name}.");
        }
    }
}

// Класс для инвентаря
public class Inventory
{
    // Поле для хранения предметов
    private readonly Dictionary<string, int> _items = new();

    // Метод для добавления предмета
    public void AddItem(string item)
    {
        if (_items.ContainsKey(item))
            _items[item]++;
        else
            _items[item] = 1;
    }

    // Метод для удаления предмета
    public void RemoveItem(string item)
    {
        if (_items.ContainsKey(item) && _items[item] > 0)
        {
            _items[item]--;
            if (_items[item] == 0)
                _items.Remove(item);
        }
    }

    // Проверка наличия предмета
    public bool ContainsItem(string item) => _items.ContainsKey(item);

    // Переопределение ToString для вывода инвентаря
    public override string ToString()
    {
        var result = "Inventory:\n";
        foreach (var item in _items)
            result += $"- {item.Key}: {item.Value}\n";
        return result;
    }
}

class Program
{
    static void Main()
    {
        // Создание персонажей
        var warrior = new RPGCharacter("Tharok", Race.Orc, "Male", 30, 100);
        var mage = new MagicCharacter("Eldrin", Race.Elf, "Male", 120, 80, 150);

        // Лечение персонажа
        mage.CastHeal(warrior, 20);

        // Вывод информации о персонажах
        Console.WriteLine(warrior);
        Console.WriteLine(mage);
    }
}

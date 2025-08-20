using System;

public class MyStack<T>
{
    private T[] _items;
    private int _count;

    public MyStack(int capacity = 10)
    {
        _items = new T[capacity];
        _count = 0;
    }

    // Добавление элемента в стек
    public void Push(T item)
    {
        if (_count == _items.Length)
        {
            Resize(_items.Length * 2);
        }
        _items[_count++] = item;
    }

    // Удаление элемента из стека
    public T Pop()
    {
        if (_count == 0)
            throw new InvalidOperationException("Стек пуст");

        T item = _items[--_count];
        _items[_count] = default; // Очистить ссылку
        return item;
    }

    // Получение верхнего элемента без удаления
    public T Peek()
    {
        if (_count == 0)
            throw new InvalidOperationException("Стек пуст");

        return _items[_count - 1];
    }

    // Проверка на пустоту
    public bool IsEmpty()
    {
        return _count == 0;
    }

    // Изменение размера массива
    private void Resize(int newCapacity)
    {
        T[] newArray = new T[newCapacity];
        Array.Copy(_items, newArray, _count);
        _items = newArray;
    }

    // Возвращаем количество элементов
    public int Count => _count;
}

public class MyQueue<T>
{
    private T[] _items;
    private int _head;
    private int _tail;
    private int _count;

    public MyQueue(int capacity = 10)
    {
        _items = new T[capacity];
        _head = 0;
        _tail = 0;
        _count = 0;
    }

    // Добавление элемента в очередь
    public void Enqueue(T item)
    {
        if (_count == _items.Length)
        {
            Resize(_items.Length * 2);
        }
        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;
        _count++;
    }

    // Удаление элемента из очереди
    public T Dequeue()
    {
        if (_count == 0)
            throw new InvalidOperationException("Очередь пуста");

        T item = _items[_head];
        _head = (_head + 1) % _items.Length;
        _count--;
        return item;
    }

    // Получение первого элемента без удаления
    public T Peek()
    {
        if (_count == 0)
            throw new InvalidOperationException("Очередь пуста");

        return _items[_head];
    }

    // Проверка на пустоту
    public bool IsEmpty()
    {
        return _count == 0;
    }

    // Изменение размера массива
    private void Resize(int newCapacity)
    {
        T[] newArray = new T[newCapacity];
        for (int i = 0; i < _count; i++)
        {
            newArray[i] = _items[(_head + i) % _items.Length];
        }
        _head = 0;
        _tail = _count;
        _items = newArray;
    }

    // Возвращаем количество элементов
    public int Count => _count;
}


class Program
{
    static void Main()
    {
        // Работа с MyStack
        MyStack<int> stack = new MyStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine("Stack:");
        Console.WriteLine("Peek: " + stack.Peek());  // Должен вывести 3

        Console.WriteLine("Pop: " + stack.Pop());   // Должен вывести 3
        Console.WriteLine("Pop: " + stack.Pop());   // Должен вывести 2
        Console.WriteLine("Is Empty: " + stack.IsEmpty());  // Должен вывести False

        // Работа с MyQueue
        MyQueue<int> queue = new MyQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Console.WriteLine("\nQueue:");
        Console.WriteLine("Peek: " + queue.Peek());  // Должен вывести 10

        Console.WriteLine("Dequeue: " + queue.Dequeue());   // Должен вывести 10
        Console.WriteLine("Dequeue: " + queue.Dequeue());   // Должен вывести 20
        Console.WriteLine("Is Empty: " + queue.IsEmpty());  // Должен вывести False
    }
}

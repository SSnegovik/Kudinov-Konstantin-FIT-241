using System;

public class MyArray<T>
{
    private T[] items;
    private int count;

    public MyArray(int capacity)
    {
        items = new T[capacity];
        count = 0;
    }

    public void Add(T item)
    {
        if (count >= items.Length)
        {
            Console.WriteLine("Массив переполнен.");
            return;
        }

        items[count++] = item;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Индекс вне диапазона.");
            return;
        }

        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }

        items[--count] = default(T);
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Индекс вне диапазона.");
            return default(T);
        }

        return items[index];
    }

    public void Print()
    {
        if (count == 0)
        {
            Console.WriteLine("Массив пуст.");
            return;
        }

        Console.WriteLine("Элементы массива:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"[{i}] {items[i]}");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Укажите максимальный размер массива:");
        int size = int.Parse(Console.ReadLine());

        MyArray<string> array = new MyArray<string>(size);

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1 - Добавить элемент");
            Console.WriteLine("2 - Удалить элемент по индексу");
            Console.WriteLine("3 - Получить элемент по индексу");
            Console.WriteLine("4 - Показать все элементы");
            Console.WriteLine("5 - Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите строку для добавления: ");
                    string value = Console.ReadLine();
                    array.Add(value);
                    break;

                case "2":
                    Console.Write("Введите индекс для удаления: ");
                    if (int.TryParse(Console.ReadLine(), out int removeIndex))
                        array.RemoveAt(removeIndex);
                    else
                        Console.WriteLine("Некорректный индекс.");
                    break;

                case "3":
                    Console.Write("Введите индекс для получения: ");
                    if (int.TryParse(Console.ReadLine(), out int getIndex))
                        Console.WriteLine("Элемент: " + array.Get(getIndex));
                    else
                        Console.WriteLine("Некорректный индекс.");
                    break;

                case "4":
                    array.Print();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}

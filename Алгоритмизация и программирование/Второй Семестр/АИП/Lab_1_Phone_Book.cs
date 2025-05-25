using System;
using System.Collections.Generic;

//Лабораторная работа 1 07.02.2025

class Contact
{
    public string FullName { get; set; }
    public List<string> Contacts { get; set; }
    public string ServiceProvider { get; set; }
    public int ConnectionYear { get; set; }
    public string Location { get; set; }

    public Contact(string fullName, List<string> contacts, string provider, int year, string location)
    {
        FullName = fullName;
        Contacts = contacts;
        ServiceProvider = provider;
        ConnectionYear = year;
        Location = location;
    }

    public override string ToString()
    {
        return $"Имя: {FullName}, Телефоны: {string.Join(", ", Contacts)}, Оператор: {ServiceProvider}, Год: {ConnectionYear}, Город: {Location}";
    }
}

class ContactBook
{
    private List<Contact> contacts = new List<Contact>();

    public void RegisterContact()
    {
        Console.Write("Введите имя: ");
        var name = Console.ReadLine();

        Console.Write("Введите номера телефонов (через запятую): ");
        var numbers = new List<string>(Console.ReadLine().Split(','));

        Console.Write("Введите название оператора: ");
        var provider = Console.ReadLine();

        Console.Write("Введите год подключения: ");
        var year = int.Parse(Console.ReadLine());

        Console.Write("Введите город: ");
        var city = Console.ReadLine();

        var contact = new Contact(name, numbers, provider, year, city);
        contacts.Add(contact);

        Console.WriteLine("Контакт успешно добавлен.");
    }

    public void SearchByProvider()
    {
        Console.Write("Введите имя оператора: ");
        var provider = Console.ReadLine();
        var found = contacts.FindAll(c => c.ServiceProvider.Equals(provider, StringComparison.OrdinalIgnoreCase));

        if (found.Count > 0)
        {
            Console.WriteLine("Найденные контакты:");
            foreach (var contact in found)
            {
                Console.WriteLine(contact);
            }
        }
        else
        {
            Console.WriteLine("Совпадений не найдено.");
        }
    }

    public void SearchByYear()
    {
        Console.Write("Введите интересующий год подключения: ");
        var year = int.Parse(Console.ReadLine());
        var found = contacts.FindAll(c => c.ConnectionYear == year);
        if (found.Count > 0)
        {
            foreach (var contact in found)
            {
                Console.WriteLine(contact);
            }
        }
        else
        {
            Console.WriteLine("Нет контактов с таким годом подключения.");
        }
    }

    public void SearchByNumber()
    {
        Console.Write("Введите номер телефона: ");
        var number = Console.ReadLine()?.Trim();
        var found = contacts.FindAll(c => c.Contacts.Contains(number));

        if (found.Count > 0)
        {
            foreach (var contact in found)
            {
                Console.WriteLine(contact);
            }
        }
        else
        {
            Console.WriteLine("Номер не найден в базе.");
        }
    }

    public void ShowMenu()
    {
        bool exitRequested = false;
        while (!exitRequested)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1 - Добавить контакт");
            Console.WriteLine("2 - Поиск по оператору");
            Console.WriteLine("3 - Поиск по году");
            Console.WriteLine("4 - Поиск по номеру");
            Console.WriteLine("5 - Выход");

            Console.Write("Выбор: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    RegisterContact();
                    break;
                case "2":
                    SearchByProvider();
                    break;
                case "3":
                    SearchByYear();
                    break;
                case "4":
                    SearchByNumber();
                    break;
                case "5":
                    exitRequested = true;
                    Console.WriteLine("Завершение работы.");
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. Повторите попытку.");
                    break;
            }
        }
    }
}

class EntryPoint
{
    static void Main()
    {
        var book = new ContactBook();
        book.ShowMenu();
    }
}

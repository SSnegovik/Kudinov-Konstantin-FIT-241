using System;
using System.Collections.Generic;
using System.Linq;

// Лабраторная работа 12 25.04.2025

public class Phone
{
    public string Brand { get; set; }
    public int Year { get; set; }
    public string Country { get; set; }

    public override string ToString()
    {
        return $"Марка: {Brand}, Год: {Year}, Страна: {Country}";
    }
}

public static class PhoneManager
{
    public static void AddPhone(List<Phone> phones)
    {
        Console.Write("Введите марку телефона: ");
        string brand = Console.ReadLine();

        Console.Write("Введите год выпуска: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Некорректный год.");
            return;
        }

        Console.Write("Введите страну использования: ");
        string country = Console.ReadLine();

        phones.Add(new Phone { Brand = brand, Year = year, Country = country });
        Console.WriteLine("Телефон добавлен.");
    }

    public static void GroupByCountry(List<Phone> phones)
    {
        var grouped = phones.GroupBy(p => p.Country);
        Console.WriteLine("\nГруппировка по странам:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"Страна: {group.Key}");
            foreach (var phone in group)
            {
                Console.WriteLine($"  {phone}");
            }
        }
    }

    public static void SearchByYear(List<Phone> phones)
    {
        Console.Write("Введите год для поиска: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Некорректный год.");
            return;
        }

        var result = phones.Where(p => p.Year == year);
        Console.WriteLine($"\nТелефоны, выпущенные в {year}:");
        foreach (var phone in result)
        {
            Console.WriteLine(phone);
        }
    }

    public static void GroupByBrand(List<Phone> phones)
    {
        var grouped = phones.GroupBy(p => p.Brand);
        Console.WriteLine("\nГруппировка по марке:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"Марка: {group.Key}");
            foreach (var phone in group)
            {
                Console.WriteLine($"  {phone}");
            }
        }
    }

    public static void ShowAll(List<Phone> phones)
    {
        if (phones.Count == 0)
        {
            Console.WriteLine("База данных пуста.");
            return;
        }

        Console.WriteLine("\nВсе телефоны:");
        foreach (var phone in phones)
        {
            Console.WriteLine(phone);
        }
    }
}

class Program
{
    static void Main()
    {
        List<Phone> phones = new List<Phone>();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nМЕНЮ:");
            Console.WriteLine("1 - Добавить телефон");
            Console.WriteLine("2 - Группировать по стране");
            Console.WriteLine("3 - Найти по году выпуска");
            Console.WriteLine("4 - Группировать по марке");
            Console.WriteLine("5 - Показать все телефоны");
            Console.WriteLine("6 - Выход");
            Console.Write("Выберите пункт: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PhoneManager.AddPhone(phones);
                    break;
                case "2":
                    PhoneManager.GroupByCountry(phones);
                    break;
                case "3":
                    PhoneManager.SearchByYear(phones);
                    break;
                case "4":
                    PhoneManager.GroupByBrand(phones);
                    break;
                case "5":
                    PhoneManager.ShowAll(phones);
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

//Лабораторная работа 14 14.05.2025

public class Laptop
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
}

public class OperatingSystem
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public bool HasLaptop { get; set; }
    public int? LaptopId { get; set; }
    public int? OSId { get; set; }
}

class Program
{
    static void Main()
    {
        var laptops = new List<Laptop>
        {
            new Laptop { Id = 1, Brand = "ASUS", Model = "ZenBook 14" },
            new Laptop { Id = 2, Brand = "Acer", Model = "Aspire 5" },
            new Laptop { Id = 3, Brand = "MSI", Model = "Modern 15" }
        };

        var operatingSystems = new List<OperatingSystem>
        {
            new OperatingSystem { Id = 1, Name = "Windows 10" },
            new OperatingSystem { Id = 2, Name = "Windows 11" },
            new OperatingSystem { Id = 3, Name = "Linux Mint" }
        };

        var users = new List<User>
        {
            new User { Id = 1, FullName = "Смирнов Алексей", HasLaptop = true, LaptopId = 1, OSId = 1 },
            new User { Id = 2, FullName = "Волкова Наталья", HasLaptop = true, LaptopId = 2, OSId = 2 },
            new User { Id = 3, FullName = "Зайцева Марина", HasLaptop = false, LaptopId = null, OSId = null },
            new User { Id = 4, FullName = "Козлов Михаил", HasLaptop = true, LaptopId = 3, OSId = 3 },
            new User { Id = 5, FullName = "Фёдоров Артём", HasLaptop = false, LaptopId = null, OSId = null }
        };

        while (true)
        {
            Console.WriteLine("\n=== МЕНЮ ===");
            Console.WriteLine("1 - Группировка по наличию ноутбука");
            Console.WriteLine("2 - Группировка по марке ноутбука");
            Console.WriteLine("3 - Группировка по операционной системе");
            Console.WriteLine("4 - Показать все данные");
            Console.WriteLine("5 - Выход");
            Console.Write("Выберите действие: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    var groupedByLaptop = users.GroupBy(u => u.HasLaptop);
                    foreach (var group in groupedByLaptop)
                    {
                        Console.WriteLine(group.Key ? "\nС ноутбуком:" : "\nБез ноутбука:");
                        foreach (var u in group)
                            Console.WriteLine($"  {u.FullName}");
                    }
                    break;

                case "2":
                    var groupedByBrand = users
                        .Where(u => u.HasLaptop && u.LaptopId.HasValue)
                        .GroupBy(u => laptops.First(l => l.Id == u.LaptopId).Brand);
                    foreach (var group in groupedByBrand)
                    {
                        Console.WriteLine($"\nМарка: {group.Key}");
                        foreach (var u in group)
                            Console.WriteLine($"  {u.FullName}");
                    }
                    break;

                case "3":
                    var groupedByOS = users
                        .Where(u => u.HasLaptop && u.OSId.HasValue)
                        .GroupBy(u => operatingSystems.First(o => o.Id == u.OSId).Name);
                    foreach (var group in groupedByOS)
                    {
                        Console.WriteLine($"\nОС: {group.Key}");
                        foreach (var u in group)
                            Console.WriteLine($"  {u.FullName}");
                    }
                    break;

                case "4":
                    var fullData = users.Select(u => new
                    {
                        u.FullName,
                        Laptop = u.HasLaptop ? "Да" : "Нет",
                        Brand = u.LaptopId.HasValue ? laptops.First(l => l.Id == u.LaptopId).Brand : "-",
                        Model = u.LaptopId.HasValue ? laptops.First(l => l.Id == u.LaptopId).Model : "-",
                        OS = u.OSId.HasValue ? operatingSystems.First(o => o.Id == u.OSId).Name : "-"
                    });

                    foreach (var u in fullData)
                    {
                        Console.WriteLine($"\nПользователь: {u.FullName}");
                        Console.WriteLine($"  Есть ноутбук: {u.Laptop}");
                        Console.WriteLine($"  Марка: {u.Brand}");
                        Console.WriteLine($"  Модель: {u.Model}");
                        Console.WriteLine($"  Операционная система: {u.OS}");
                    }
                    break;

                case "5":
                    Console.WriteLine("Выход...");
                    return;

                default:
                    Console.WriteLine("Неверный ввод.");
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

//Лабораторная работа 13 02.05.2025

public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
}

public class ProductMovement
{
    public int ProductId { get; set; }
    public int SupplierId { get; set; }
    public string Prefix { get; set; } // "Поступление" или "Продажа"
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
    public decimal PricePerUnit { get; set; }
}

class Program
{
    static void Main()
    {
        // Инициализация базы
        List<Supplier> suppliers = new List<Supplier>
        {
            new Supplier { Id = 1, Name = "Поставщик А", Phone = "123-456" },
            new Supplier { Id = 2, Name = "Поставщик Б", Phone = "789-012" }
        };

        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Title = "Ноутбук" },
            new Product { Id = 2, Title = "Принтер" },
            new Product { Id = 3, Title = "Монитор" }
        };

        List<ProductMovement> movements = new List<ProductMovement>
        {
            new ProductMovement { ProductId = 1, SupplierId = 1, Prefix = "Поступление", Date = DateTime.Parse("2024-01-10"), Quantity = 10, PricePerUnit = 50000 },
            new ProductMovement { ProductId = 1, SupplierId = 1, Prefix = "Продажа", Date = DateTime.Parse("2024-01-15"), Quantity = 4, PricePerUnit = 55000 },
            new ProductMovement { ProductId = 2, SupplierId = 2, Prefix = "Поступление", Date = DateTime.Parse("2024-02-01"), Quantity = 5, PricePerUnit = 15000 },
            new ProductMovement { ProductId = 2, SupplierId = 2, Prefix = "Продажа", Date = DateTime.Parse("2024-02-05"), Quantity = 2, PricePerUnit = 17000 },
            new ProductMovement { ProductId = 3, SupplierId = 1, Prefix = "Поступление", Date = DateTime.Parse("2024-03-01"), Quantity = 7, PricePerUnit = 25000 }
        };


        Console.WriteLine("\n1. Остатки товаров:");
        var stock = products.Select(p => new
        {
            Product = p.Title,
            Quantity = movements
                .Where(m => m.ProductId == p.Id)
                .Sum(m => m.Prefix == "Поступление" ? m.Quantity : -m.Quantity)
        });

        foreach (var item in stock)
        {
            Console.WriteLine($"{item.Product} — Остаток: {item.Quantity}");
        }

        Console.WriteLine("\n2. Поставки по поставщикам:");
        var supplies = movements
            .Where(m => m.Prefix == "Поступление")
            .GroupBy(m => m.SupplierId);

        foreach (var group in supplies)
        {
            var supplier = suppliers.First(s => s.Id == group.Key);
            Console.WriteLine($"\nПоставщик: {supplier.Name}");

            foreach (var movement in group)
            {
                var product = products.First(p => p.Id == movement.ProductId);
                Console.WriteLine($"  {product.Title}, {movement.Date.ToShortDateString()}, {movement.Quantity} шт.");
            }
        }

        Console.WriteLine("\n3. Продажи, сгруппированные по дате:");
        var sales = movements
            .Where(m => m.Prefix == "Продажа")
            .GroupBy(m => m.Date.Date);

        foreach (var group in sales.OrderBy(g => g.Key))
        {
            Console.WriteLine($"\nДата: {group.Key.ToShortDateString()}");

            foreach (var movement in group)
            {
                var product = products.First(p => p.Id == movement.ProductId);
                Console.WriteLine($"  {product.Title} — {movement.Quantity} шт. по {movement.PricePerUnit} руб.");
            }
        }
    }
}

using System;
using System.Collections.Generic;

//Лабораторная работа 10 11.04.2025

public struct BorrowRecord
{
    public DateTime BorrowDate;
    public DateTime? ReturnDate;

    public BorrowRecord(DateTime borrowDate, DateTime? returnDate)
    {
        BorrowDate = borrowDate;
        ReturnDate = returnDate;
    }
}

public class Book
{
    public string Writer;
    public string Name;
    public int PublishYear;
    public string PublishingHouse;
    public List<BorrowRecord> BorrowHistory;

    public Book(string writer, string name, int publishYear, string publishingHouse)
    {
        Writer = writer;
        Name = name;
        PublishYear = publishYear;
        PublishingHouse = publishingHouse;
        BorrowHistory = new List<BorrowRecord>();
    }

    public Book(string writer, string name, int publishYear, string publishingHouse, BorrowRecord record)
        : this(writer, name, publishYear, publishingHouse)
    {
        BorrowHistory.Add(record);
    }
}

class Program
{
    static void Main()
    {
        List<Book> catalog = new List<Book>
        {
            new Book("Чехов", "Палата №6", 1892, "Северный вестник"),
            new Book("Булгаков", "Мастер и Маргарита", 1967, "Москва"),
            new Book("Тургенев", "Отцы и дети", 1862, "Русская мысль",
                new BorrowRecord(new DateTime(2025, 4, 5), new DateTime(2025, 4, 20))),
            new Book("Лермонтов", "Герой нашего времени", 1840, "Отечественные записки",
                new BorrowRecord(new DateTime(2025, 5, 10), null))
        };

        Console.WriteLine("Книги, которые никогда не выдавались:");
        foreach (var book in catalog)
        {
            if (book.BorrowHistory.Count == 0)
            {
                Console.WriteLine($"{book.Writer} — \"{book.Name}\" ({book.PublishYear}, {book.PublishingHouse})");
            }
        }

        Console.WriteLine("\nКниги, которые не возвращены:");
        foreach (var book in catalog)
        {
            foreach (var record in book.BorrowHistory)
            {
                if (record.ReturnDate == null)
                {
                    Console.WriteLine($"{book.Writer} — \"{book.Name}\" ({book.PublishYear}, {book.PublishingHouse}), выдана: {record.BorrowDate:dd.MM.yyyy}");
                    break;
                }
            }
        }
    }
}

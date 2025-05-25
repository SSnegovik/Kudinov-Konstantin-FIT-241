using System;
using System.Collections.Generic;
using System.Linq;

//Лабораторная работа 8_2 28.03.2025

class Program
{
    static void Main()
    {
        List<string> words = new List<string> { "медаль", "пункт", "мечта", "облако", "город", "морда" };

        var filtered = words.Where(s => s.StartsWith("м")).ToList();

        Console.WriteLine("Слова, начинающиеся на 'м':");
        foreach (var word in filtered)
        {
            Console.WriteLine(word);
        }
    }
}

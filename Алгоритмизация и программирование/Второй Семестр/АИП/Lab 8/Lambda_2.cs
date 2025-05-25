using System;
using System.Collections.Generic;
using System.Linq;

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

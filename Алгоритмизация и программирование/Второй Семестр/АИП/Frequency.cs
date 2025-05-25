using System;

//Лабораторная работа 16 23.05.2025

class Program
{
    unsafe static void Main()
    {
        Console.Write("Введите количество строк: ");
        if (!int.TryParse(Console.ReadLine(), out int linesCount) || linesCount <= 0)
        {
            Console.WriteLine("Неверное количество строк.");
            return;
        }

        int* frequency = stackalloc int[256];

        for (int i = 0; i < 256; i++)
        {
            frequency[i] = 0;
        }

        Console.WriteLine("Введите строки:");

        for (int i = 0; i < linesCount; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < line.Length; j++)
            {
                byte ch = (byte)line[j];
                frequency[ch]++;
            }
        }

        int minFreq = int.MaxValue;
        int maxFreq = int.MinValue;

        for (int i = 0; i < 256; i++)
        {
            int freq = frequency[i];
            if (freq > 0 && freq < minFreq)
                minFreq = freq;
            if (freq > maxFreq)
                maxFreq = freq;
        }

        Console.WriteLine("\nСимволы, встречавшиеся реже всего:");

        for (int i = 0; i < 256; i++)
        {
            if (frequency[i] == minFreq)
                Console.WriteLine($"Символ '{(char)i}' (код {(byte)i}) встречался {minFreq} раз(а)");
        }

        Console.WriteLine("\nСимволы, встречавшиеся чаще всего:");

        for (int i = 0; i < 256; i++)
        {
            if (frequency[i] == maxFreq)
                Console.WriteLine($"Символ '{(char)i}' (код {(byte)i}) встречался {maxFreq} раз(а)");
        }
    }
}

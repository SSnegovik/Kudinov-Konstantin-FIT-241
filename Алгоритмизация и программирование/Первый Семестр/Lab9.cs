using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        //Лабораторная работа 21.11.2024
        //Задание 1 Количество строк содержащих сочетание "a*b"
        Console.WriteLine("Введите строки (пустая строка завершает ввод):");

        int count = 0;
        string pattern = @"a.b";

        while (true){
            string line = Console.ReadLine();
            if (line == ""){
                break;
            }
            line = line.ToLower();

            if (Regex.IsMatch(line, pattern)){
                count++;
            }
        }

        Console.WriteLine($"Количество строк, содержащих сочетание 'a*b': {count}");
        Console.WriteLine();
        
        //Задание 2 Максимальная длина подстроки содержащая сочетание "abc"

        string validChars = "abcABC"; // Допустимые символы
        int maxLength = 0, currentLength = 0;
        
        Console.WriteLine("Введите строки (пустая строка завершает ввод):");
        while (true){
        string lines = Console.ReadLine();
        if (lines == ""){
            break;
        }

        foreach (char c in lines)
        {
            if (validChars.Contains(c))
            {
                currentLength++;
                maxLength = Math.Max(maxLength, currentLength);
            }
            else
            {
                currentLength = 0;
            }
        }
        Console.WriteLine($"Максимальная длина подстроки содержащая сочетание abc: {maxLength}");
        Console.WriteLine();
        }
    }
}

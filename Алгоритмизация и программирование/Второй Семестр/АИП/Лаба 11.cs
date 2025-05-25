using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        string[] lines = File.ReadAllLines(inputFile);
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (string line in lines)
            {
                // Поиск всех чисел в строке (наборов подряд идущих цифр)
                MatchCollection matches = Regex.Matches(line, @"\d+");

                bool hasEvenNumber = false;

                foreach (Match match in matches)
                {
                    string numberStr = match.Value;
                    if (int.TryParse(numberStr, out int number))
                    {
                        if (number % 2 == 0)
                        {
                            hasEvenNumber = true;
                            break;
                        }
                    }
                }

                if (hasEvenNumber)
                {
                    writer.WriteLine(line);
                }
            }
        }

        Console.WriteLine("Результат записан в файл: " + outputFile);
    }
}

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество солдат: ");
        int n = int.Parse(Console.ReadLine());

        int groups = CountGroups(n);
        Console.Write("Количество групп по 3 человека: ");
        Console.WriteLine(groups);
    }

    static int CountGroups(int n)
    {
        if(n == 3){
            return 1;
        }
        if(n <= 3){
            return 0;
        }

        int evenCount = n / 2;
        int oddCount = n - evenCount;

        return CountGroups(evenCount) + CountGroups(oddCount);
    }
}
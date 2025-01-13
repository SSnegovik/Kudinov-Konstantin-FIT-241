using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int a = 1;
        int b = 0;
        Console.WriteLine("Введите количество операций");
        int n = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Введите операции через Enter");

        for (int i = 0; i < n; i++){
            string[] input = Console.ReadLine().Split();
            char operation = input[0][0];
            string value = input[1];
        
            if (value == "x"){
                if (operation == '+') a += 1;
                else if (operation == '-') a -= 1;
            }
            else{
                int number = int.Parse(value);
                if (operation == '+') b += number;
                else if (operation == '-') b -= number;
                else if (operation == '*'){
                    a *= number;
                    b *= number;
                }
            }
        }
        Console.WriteLine("Введите полученный результат");
        int result = int.Parse(Console.ReadLine());

        int x = (result - b) / a;
        
        Console.Write("Загаданное число: ");
        Console.WriteLine(x);
    }
}


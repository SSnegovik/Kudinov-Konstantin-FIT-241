using System;

//Лабораторная работа 8_1 28.03.2025

class Program
{
    static void Main()
    {
        Func<double, double, double> sum = (a, b) => a + b;
        Func<double, double, double> dif = (a, b) => a - b;
        Func<double, double, double> mul = (a, b) => a * b;
        Func<double, double, double?> div = (a, b) => 
        {
            if (b == 0)
            {
                Console.WriteLine("Деление на ноль невозможно");
                return null;
            }
            else return a / b;
        };
        double x = 10;
        double y = 0;
        
        Console.WriteLine($"Сложение: {x} + {y} = {sum(x, y)}");
        Console.WriteLine($"Вычитание: {x} - {y} = {dif(x, y)}");
        Console.WriteLine($"Умножение: {x} * {y} = {mul(x, y)}");
        Console.WriteLine($"Деление: {x} / {y} = {div(x, y)}");
        if (div(x, y).HasValue) Console.WriteLine($"{x} / {y} = {div(x, y)}");
    }
}

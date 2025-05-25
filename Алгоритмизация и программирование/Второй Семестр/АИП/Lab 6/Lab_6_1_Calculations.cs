using System;

//Лаббораторная работа 6_1 21.03.2025

public delegate int OperationHandler();

class MathProcessor
{
    public int A { get; set; }
    public int B { get; set; }

    public MathProcessor(int a, int b)
    {
        A = a;
        B = b;
    }

    public int Sum()
    {
        return A + B;
    }

    public int Difference()
    {
        return A - B;
    }

    public int Product()
    {
        return A * B;
    }

    public int Quotient()
    {
        if (B == 0)
        {
            throw new DivideByZeroException("Нельзя делить на ноль");
        }
        return A / B;
    }
}

class Program
{
    static void Main()
    {
        MathProcessor obj1 = new MathProcessor(10, 5);
        MathProcessor obj2 = new MathProcessor(20, 4);

        OperationHandler task1 = () =>
        {
            int result1 = obj1.Sum();
            Console.WriteLine($"Сложение: {result1}");

            int result2 = result1 * obj1.B;
            Console.WriteLine($"Умножение: {result2}");

            int result3 = result2 / obj1.B;
            Console.WriteLine($"Деление: {result3}");

            return result3;
        };

        OperationHandler task2 = () =>
        {
            int part1 = obj2.Quotient();
            Console.WriteLine($"Частное: {part1}");

            int part2 = part1 - obj2.B;
            Console.WriteLine($"Разность: {part2}");

            int part3 = part2 * obj2.B;
            Console.WriteLine($"Произведение: {part3}");

            return part3;
        };

        Console.WriteLine("Результаты первого вычисления:");
        task1();

        Console.WriteLine("\nРезультаты второго вычисления:");
        task2();
    }
}
            

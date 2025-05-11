using System;
using System.Collections.Generic;
using System.Globalization;

public class PostfixCalculator
{
    public static double Evaluate(string input)
    {
        var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var stack = new Stack<double>();

        foreach (var token in tokens)
        {
            if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
            {
                // Если это число — кладем в стек
                stack.Push(number);
            }
            else
            {
                // Если это оператор — извлекаем два последних числа
                if (stack.Count < 2)
                {
                    throw new InvalidOperationException("Недостаточно операндов для операции");
                }

                double right = stack.Pop();
                double left = stack.Pop();

                double result = token switch
                {
                    "+" => left + right,
                    "-" => left - right,
                    "*" => left * right,
                    "/" => right != 0 ? left / right : throw new DivideByZeroException("Деление на ноль"),
                    _ => throw new InvalidOperationException($"Неизвестный оператор: {token}")
                };

                stack.Push(result);
            }
        }

        if (stack.Count != 1)
        {
            throw new InvalidOperationException("Некорректное выражение");
        }

        return stack.Pop();
    }

    public static void Main()
    {
        Console.Write("Введите выражение в постфиксной записи: ");
        string input = Console.ReadLine();

        try
        {
            double result = Evaluate(input);
            Console.WriteLine($"Результат: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}



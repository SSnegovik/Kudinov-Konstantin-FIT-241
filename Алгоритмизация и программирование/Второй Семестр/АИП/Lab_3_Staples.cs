using System;
using System.Collections.Generic;

//Лабараторная работа 3 21.02.2025

public class ExpressionValidator
{
    private static readonly Dictionary<char, char> MatchingBrackets = new Dictionary<char, char>
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' }
    };

    public static bool HasValidBrackets(string input)
    {
        var stack = new Stack<char>();

        foreach (var ch in input)
        {
            if (MatchingBrackets.ContainsKey(ch))
            {
                stack.Push(ch);
            }
            else if (MatchingBrackets.ContainsValue(ch))
            {
                if (stack.Count == 0 || MatchingBrackets[stack.Pop()] != ch)
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }

    public static void Main(string[] args)
    {
        Console.Write("Введите выражение: ");
        var userInput = Console.ReadLine();

        if (HasValidBrackets(userInput))
        {
            Console.WriteLine("Скобки расставлены правильно.");
        }
        else
        {
            Console.WriteLine("Ошибка в расстановке скобок.");
        }
    }
}



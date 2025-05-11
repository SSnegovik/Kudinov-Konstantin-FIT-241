using System;
using System.Collections.Generic;
using System.Threading;
//Лабораторная работа по АИП №7.1

public class Runner
{
    public string Label { get; }
    public double DistanceCovered { get; private set; }

    private static readonly Random random = new Random();

    public Runner(string label)
    {
        Label = label;
        DistanceCovered = 0;
    }

    public void Advance()
    {
        double pace = random.NextDouble() * 0.9 + 0.1; // диапазон от 0.1 до 1.0
        DistanceCovered += pace;
    }
}

public class Competition
{
    private List<Runner> participants;
    private readonly double trackLength;

    public Competition(List<Runner> runners, double trackLength)
    {
        participants = runners;
        this.trackLength = trackLength;
    }

    public void Begin()
    {
        bool hasWinner = false;

        while (!hasWinner)
        {
            Console.Clear();
            foreach (var participant in participants)
            {
                participant.Advance();
                Console.WriteLine($"{participant.Label}: {participant.DistanceCovered:F2} м");

                if (participant.DistanceCovered >= trackLength)
                {
                    Console.WriteLine($"\n Победитель: {participant.Label}!");
                    hasWinner = true;
                    break;
                }
            }
            Thread.Sleep(400);
        }
    }
}

public class App
{
    public static void Main()
    {
        var contenders = new List<Runner>
        {
            new Runner("Рыжик"),
            new Runner("Гром"),
            new Runner("Быстряк")
        };

        Console.WriteLine("Участники выходят на стартовую прямую...\n");
        foreach (var r in contenders)
        {
            Console.WriteLine($" {r.Label} готовится...");
            Thread.Sleep(700);
        }

        Console.WriteLine("\nСтарт через:");
        for (int i = 3; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }

        Console.WriteLine("СТАРТ!\n");

        var race = new Competition(contenders, 10.0);
        race.Begin();
    }
}

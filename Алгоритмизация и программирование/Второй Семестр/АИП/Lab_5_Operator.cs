using System;
using System.Collections.Generic;

//Лабораторная работа 5 07.03.2025

class Contact
{
    public string Number { get; set; }
    public string Name { get; set; }
    public string Provider { get; set; }

    public Contact(string number, string name, string provider)
    {
        Number = number;
        Name = name;
        Provider = provider;
    }
}

class Program
{
    static void Main()
    {
        List<Contact> contacts = new List<Contact>
        {
            new Contact("1234567890", "Елизавета", "Yota"),
            new Contact("0987654321", "Роман", "MTS"),
            new Contact("1112223333", "Анастасия", "Tele2"),
            new Contact("4445556666", "Михаил", "MTS"),
            new Contact("7778889999", "Петр", "Beeline"),
            new Contact("2223334445", "Константин", "MTS")
        };

        string commonProvider = GetTopProvider(contacts);
        Console.WriteLine($"Наиболее популярный оператор: {commonProvider}");
    }

    static string GetTopProvider(List<Contact> list)
    {
        Dictionary<string, int> frequencyMap = new Dictionary<string, int>();

        foreach (var entry in list)
        {
            if (frequencyMap.ContainsKey(entry.Provider))
            {
                frequencyMap[entry.Provider]++;
            }
            else
            {
                frequencyMap[entry.Provider] = 1;
            }
        }

        string topProvider = "";
        int maxFrequency = 0;

        foreach (var pair in frequencyMap)
        {
            if (pair.Value > maxFrequency)
            {
                maxFrequency = pair.Value;
                topProvider = pair.Key;
            }
        }

        return topProvider;
    }
}

         
            
            
            
            
            

using System;
//Лабараторная работа 13 19.12.2024

class Animal{
    public string Name { get; set; }

    public Animal(string name){
        Name = name;
    }

    public override string ToString(){
        return $"Животное: {Name}";
    }
}

class Bird : Animal{
    public string Habitat { get; set; }
    public string WinterDestination { get; set; }

    public Bird(string name, string habitat, string winterDestination) : base(name){
        Habitat = habitat;
        WinterDestination = winterDestination;
    }

    public override string ToString(){
        return $"Птица: {Name}, Обитание: {Habitat}, Зимовка: {WinterDestination}";
    }
}

class Mammal : Animal{
    public string Habitat { get; set; }
    public double Weight { get; set; }

    public Mammal(string name, string habitat, double weight) : base(name){
        Habitat = habitat;
        Weight = weight;
    }

    public override string ToString(){
        return $"Млекопитающее: {Name}, Обитание: {Habitat}, Вес: {Weight} кг";
    }
}

class Program{
    static void Main(){
        Console.Write("Введите количество птиц: ");
        int birdCount = int.Parse(Console.ReadLine());
        Bird[] birds = new Bird[birdCount];

        for (int i = 0; i < birdCount; i++){
            Console.Write($"Введите название птицы {i + 1}: ");
            string name = Console.ReadLine();

            Console.Write($"Введите место обитания птицы {i + 1}: ");
            string habitat = Console.ReadLine();

            Console.Write($"Введите место зимовки птицы {i + 1}: ");
            string winterDestination = Console.ReadLine();

            birds[i] = new Bird(name, habitat, winterDestination);
        }

        Console.Write("Введите количество млекопитающих: ");
        int mammalCount = int.Parse(Console.ReadLine());
        Mammal[] mammals = new Mammal[mammalCount];

        for (int i = 0; i < mammalCount; i++){
            Console.Write($"Введите название млекопитающего {i + 1}: ");
            string name = Console.ReadLine();

            Console.Write($"Введите место обитания млекопитающего {i + 1}: ");
            string habitat = Console.ReadLine();

            Console.Write($"Введите вес млекопитающего {i + 1}: ");
            double weight = double.Parse(Console.ReadLine());

            mammals[i] = new Mammal(name, habitat, weight);
        }

        Console.Write("\nВведите место обитания для выборки: ");
        string searchHabitat = Console.ReadLine();
        Console.WriteLine("\nПтицы с заданным местом обитания:");
        foreach (var bird in birds){
            if (bird.Habitat == searchHabitat){
                Console.WriteLine(bird);
            }
        }

        Console.WriteLine("\nМлекопитающие с заданным местом обитания:");
        foreach (var mammal in mammals){
            if (mammal.Habitat == searchHabitat){
                Console.WriteLine(mammal);
            }
        }

        Console.Write("\nВведите место зимовки для выборки птиц: ");
        string searchWinterDestination = Console.ReadLine();
        Console.WriteLine("\nПтицы с заданным местом зимовки:");
        foreach (var bird in birds){
            if (bird.WinterDestination == searchWinterDestination){
                Console.WriteLine(bird);
            }
        }

        Console.Write("\nВведите минимальный вес для выборки млекопитающих: ");
        double minWeight = double.Parse(Console.ReadLine());
        Console.WriteLine("\nМлекопитающие с весом больше указанного:");
        foreach (var mammal in mammals){
            if (mammal.Weight >= minWeight){
                Console.WriteLine(mammal);
            }
        }
    }
}

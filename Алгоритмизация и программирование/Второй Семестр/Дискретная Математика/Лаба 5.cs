using System;
using System.Collections.Generic;

//Лабораторная работа по дискретной математике №5 07.03.2025

class BellmanFord
{
    class Edge
    {
        public int Source, Destination, Weight;
        public Edge(int source, int destination, int weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }
    }

    int vertices;
    List<Edge> edges;

    public BellmanFord(int vertices)
    {
        this.vertices = vertices;
        edges = new List<Edge>();
    }

    public void AddEdge(int source, int destination, int weight)
    {
        edges.Add(new Edge(source, destination, weight));
    }
    
    // Алгоритм Форда-Беллмана
    public void Run(int startVertex)
    {
        int[] distance = new int[vertices];
        for (int i = 0; i < vertices; i++)
            distance[i] = int.MaxValue;

        distance[startVertex] = 0;

        for (int i = 1; i < vertices; i++)
        {
            foreach (var edge in edges)
            {
                if (distance[edge.Source] != int.MaxValue && distance[edge.Source] + edge.Weight < distance[edge.Destination])
                {
                    distance[edge.Destination] = distance[edge.Source] + edge.Weight;
                }
            }
        }

        foreach (var edge in edges)
        {
            if (distance[edge.Source] != int.MaxValue && distance[edge.Source] + edge.Weight < distance[edge.Destination])
            {
                Console.WriteLine("Граф содержит отрицательный цикл.");
                return;
            }
        }

        Console.WriteLine("Вершина \t Расстояние от источника");
        for (int i = 0; i < vertices; i++)
        {
            Console.WriteLine($"{i} \t\t {(distance[i] == int.MaxValue ? "∞" : distance[i].ToString())}");
        }
    }

    static void Main()
    {
        BellmanFord graph = new BellmanFord(5);//Количество вершин
        graph.AddEdge(0, 1, -1);// (Начальная вершина, Конечная вершина, Вес)
        graph.AddEdge(0, 2, 4);
        graph.AddEdge(1, 2, 3);
        graph.AddEdge(1, 3, 2);
        graph.AddEdge(1, 4, 2);
        graph.AddEdge(3, 2, 5);
        graph.AddEdge(3, 1, 1);
        graph.AddEdge(4, 3, -3);

        graph.Run(0); //Стартовая вершина
    }
}

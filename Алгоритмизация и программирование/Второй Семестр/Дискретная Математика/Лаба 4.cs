using System;
using System.Collections.Generic;

//Лабараторная работа по дискретной математикике №4 28.02.2025

class Graph
{
    int V;
    List<(int, int)>[] adj;

    public Graph(int vertices)
    {
        V = vertices;
        adj = new List<(int, int)>[V];
        for (int i = 0; i < V; i++)
        {
            adj[i] = new List<(int, int)>();
        }
    }
    
    public void AddEdge(int u, int v, int weight)
    {
        adj[u].Add((v, weight));
        adj[v].Add((u, weight));
    }

    public (int[], int[]) Dijkstra(int start)
    {
        int[] dist = new int[V];
        int[] parent = new int[V];
        bool[] visited = new bool[V];

        for (int i = 0; i < V; i++)
        {
            dist[i] = int.MaxValue;
            parent[i] = -1;
            visited[i] = false;
        }
        dist[start] = 0;
        
        //Алгоритм Дейкстры
        for (int i = 0; i < V; i++)
        {
            int u = -1;
            int minDist = int.MaxValue;
            for (int j = 0; j < V; j++)
            {
                if (!visited[j] && dist[j] < minDist)
                {
                    u = j;
                    minDist = dist[j];
                }
            }

            if (u == -1) 
            {
                break;
            }

            visited[u] = true;

            foreach (var edge in adj[u])
            {
                int v = edge.Item1;
                int weight = edge.Item2;

                if (dist[u] + weight < dist[v])
                {
                    dist[v] = dist[u] + weight;
                    parent[v] = u;
                }
            }
        }
        return (dist, parent);
    }
}

class Program
{
    static void Main()
    {
        int vertices = 6;
        Graph g = new Graph(vertices);

        // Добавление рёбер: (начальная вершина, конечная вершина, вес)
        g.AddEdge(0, 1, 7);
        g.AddEdge(0, 2, 9);
        g.AddEdge(0, 5, 14);
        g.AddEdge(1, 2, 10);
        g.AddEdge(1, 3, 15);
        g.AddEdge(2, 3, 11);
        g.AddEdge(2, 5, 2);
        g.AddEdge(3, 4, 6);
        g.AddEdge(4, 5, 9);

        int start = 0;
        int end = 4;
        
        var (dist, parent) = g.Dijkstra(start);

        if (dist[end] == int.MaxValue)
        {
            Console.WriteLine("Нет пути от вершины " + start + " до вершины " + end);
        }
        else
        {
            Console.WriteLine($"Кратчайшее расстояние от {start} до {end}: {dist[end]}");
        }
    }
}

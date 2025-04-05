using System;
using System.Collections.Generic;

// Лабораторная работа №3 21.02.2025

class BridgeFinder
{
    private List<int>[] graph;
    private bool[] visited;
    private int[] tin, low;
    private int timer;
    private List<(int, int)> bridges;

    public BridgeFinder(int n)
    {
        graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }
        visited = new bool[n];
        tin = new int[n];
        low = new int[n];
        timer = 0;
        bridges = new List<(int, int)>();
    }

    public void AddEdge(int u, int v)
    {
        graph[u].Add(v);
        graph[v].Add(u);
    }

    public List<(int, int)> FindBridges()
    {
        for (int i = 0; i < graph.Length; i++)
        {
            if (!visited[i])
                Dfs(i, -1);
        }
        return bridges;
    }

    private void Dfs(int v, int parent)
    {
        visited[v] = true;
        tin[v] = low[v] = timer++;

        foreach (int to in graph[v])
        {
            if (to == parent) 
            {
                continue;
            }

            if (visited[to])
            {
                low[v] = Math.Min(low[v], tin[to]);
            }
            else
            {
                Dfs(to, v);
                low[v] = Math.Min(low[v], low[to]);
                if (low[to] > tin[v])
                {
                    bridges.Add((v, to));
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {

        int n = 6; //количество вершин
        BridgeFinder finder = new BridgeFinder(n);

        finder.AddEdge(0, 1);
        finder.AddEdge(1, 2);
        finder.AddEdge(1, 3);  //ребра
        finder.AddEdge(3, 4);
        finder.AddEdge(2, 4);

        var bridges = finder.FindBridges();

        Console.WriteLine("Мосты в графе:");
        foreach (var bridge in bridges)
        {
            Console.WriteLine($"{bridge.Item1} - {bridge.Item2}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

//Лабораторная работа по дискретной математике №2 "Алгоритм Крускала" 14.02.2025

class Edge
{
    public int Src, Dest, Weight;
    public Edge(int src, int dest, int weight)
    {
        Src = src;
        Dest = dest;
        Weight = weight;
    }
}

class Graph
{
    private int V;
    private List<Edge> edges;

    public Graph(int v)
    {
        V = v;
        edges = new List<Edge>();
    }

    public void AddEdge(int src, int dest, int weight)
    {
        edges.Add(new Edge(src, dest, weight));
    }

    private int Find(int[] parent, int i)
    {
        if (parent[i] == i) return i;
        return parent[i] = Find(parent, parent[i]);
    }

    private void Union(int[] parent, int[] rank, int x, int y)
    {
        int xRoot = Find(parent, x);
        int yRoot = Find(parent, y);
        
        if (rank[xRoot] < rank[yRoot])
            parent[xRoot] = yRoot;
        else if (rank[xRoot] > rank[yRoot])
            parent[yRoot] = xRoot;
        else
        {
            parent[yRoot] = xRoot;
            rank[xRoot]++;
        }
    }

    public void KruskalMST()
    {
        edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));
        
        int[] parent = new int[V];
        int[] rank = new int[V];
        
        for (int i = 0; i < V; i++)
        {
            parent[i] = i;
            rank[i] = 0;
        }

        List<Edge> result = new List<Edge>();

        foreach (var edge in edges)
        {
            int x = Find(parent, edge.Src);
            int y = Find(parent, edge.Dest);
            
            if (x != y)
            {
                result.Add(edge);
                Union(parent, rank, x, y);
            }
        }

        Console.WriteLine("Минимальное остовное дерево:");
        foreach (var edge in result)
        {
            Console.WriteLine($"{edge.Src} - {edge.Dest}: {edge.Weight}");
        }
    }
}

class Program
{
    static void Main()
    {
        Graph g = new Graph(4);
        g.AddEdge(0, 1, 10);
        g.AddEdge(0, 2, 6);
        g.AddEdge(0, 3, 5);
        g.AddEdge(1, 3, 15);
        g.AddEdge(2, 3, 4);

        g.KruskalMST();
    }
}

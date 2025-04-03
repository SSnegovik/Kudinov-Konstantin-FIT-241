using System;
using System.Collections.Generic;

class PrimAlgorithm
{
    // Лабораторная работа по дискретной математики №2 "Алгоритм Прима" 14.02.2025
    
    public static void PrimMST(int[,] graph)
    {
        int V = graph.GetLength(0);
        int[] parent = new int[V];
        int[] vertex = new int[V];
        bool[] mstSet = new bool[V]; 
        int totalWeight = 0; 

        for (int i = 0; i < V; i++)
        {
            vertex[i] = int.MaxValue;
            mstSet[i] = false;
        }

        vertex[0] = 0;
        parent[0] = -1;

        for (int count = 0; count < V - 1; count++)
        {
            int u = MinVertex(vertex, mstSet, V);
            mstSet[u] = true;

            for (int v = 0; v < V; v++)
            {
                if (graph[u, v] != 0 && !mstSet[v] && graph[u, v] < vertex[v])
                {
                    parent[v] = u;
                    vertex[v] = graph[u, v];
                }
            }
        }

        totalWeight = CalculateTotalWeight(parent, graph, V);
        PrintMST(parent, graph, V, totalWeight);
    }

    private static int MinVertex(int[] vertex, bool[] mstSet, int V)
    {
        int min = int.MaxValue, minIndex = 0;

        for (int v = 0; v < V; v++)
        {
            if (!mstSet[v] && vertex[v] < min)
            {
                min = vertex[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    private static int CalculateTotalWeight(int[] parent, int[,] graph, int V)
    {
        int sum = 0;
        for (int i = 1; i < V; i++)
            sum += graph[i, parent[i]];
        return sum;
    }

    private static void PrintMST(int[] parent, int[,] graph, int V, int totalWeight)
    {
        Console.WriteLine("Ребро \tВес");
        for (int i = 1; i < V; i++)
            Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i, parent[i]]);
        Console.WriteLine("Минимальный вес: " + totalWeight);
    }

    public static void Main()
    {
        int[,] graph = {
            { 0, 2, 0, 6, 0 },
            { 2, 0, 3, 8, 5 },
            { 0, 3, 0, 0, 7 },
            { 6, 8, 0, 0, 9 },
            { 0, 5, 7, 9, 0 }
        };

        PrimMST(graph);
    }
}
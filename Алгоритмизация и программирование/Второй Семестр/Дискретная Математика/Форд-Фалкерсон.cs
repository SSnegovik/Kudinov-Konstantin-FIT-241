using System;
using System.Collections.Generic;

class FordFulkerson
{
    static int V;

    static bool DFS(int[,] rGraph, int s, int t, int[] parent)
    {
        bool[] visited = new bool[V];
        Stack<int> stack = new Stack<int>();
        stack.Push(s);
        visited[s] = true;
        parent[s] = -1;

        while (stack.Count > 0)
        {
            int u = stack.Pop();

            for (int v = 0; v < V; v++)
            {
                if (!visited[v] && rGraph[u, v] > 0)
                {
                    parent[v] = u;
                    visited[v] = true;
                    stack.Push(v);
                }
            }
        }

        return visited[t];
    }

    public static int MaxFlow(int[,] graph, int s, int t)
    {
        V = graph.GetLength(0);
        int[,] rGraph = new int[V, V];

        for (int u = 0; u < V; u++)
            for (int v = 0; v < V; v++)
                rGraph[u, v] = graph[u, v];

        int[] parent = new int[V];
        int maxFlow = 0;

        while (DFS(rGraph, s, t, parent))
        {
            int pathFlow = int.MaxValue;
            for (int v = t; v != s; v = parent[v])
            {
                int u = parent[v];
                pathFlow = Math.Min(pathFlow, rGraph[u, v]);
            }

            for (int v = t; v != s; v = parent[v])
            {
                int u = parent[v];
                rGraph[u, v] -= pathFlow;
                rGraph[v, u] += pathFlow;
            }

            maxFlow += pathFlow;
        }

        return maxFlow;
    }

    static void Main()
    {
        int[,] graph = {
            { 0, 16, 13, 0, 0, 0 },
            { 0, 0, 10, 12, 0, 0 },
            { 0, 4, 0, 0, 14, 0 },
            { 0, 0, 9, 0, 0, 20 },
            { 0, 0, 0, 7, 0, 4 },
            { 0, 0, 0, 0, 0, 0 }
        };

        int source = 0, sink = 5;

        Console.WriteLine("Максимальный поток: " + MaxFlow(graph, source, sink));
    }
}

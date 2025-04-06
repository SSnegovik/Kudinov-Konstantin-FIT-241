using System;

//Лабараторная работа по дискретной математике №6 14.03.2025

class Floyd
{
    int vertices;
    int[,] dist;
    static int INF = int.MaxValue;

    public Floyd(int[,] graph, int vertices)
    {
        this.vertices = vertices;
        dist = new int[vertices, vertices];

        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                dist[i, j] = graph[i, j];
            }
        }
    }
    
    // Алгоритм Флойда 
    public void Run()
    {
        for (int k = 0; k < vertices; k++)
        {
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (dist[i, k] != INF && dist[k, j] != INF && dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
            }
        }

        PrintResult();
    }

    private void PrintResult()
    {
        Console.WriteLine("Матрица кратчайших расстояний:");
        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                if (dist[i, j] == INF)
                {
                    Console.Write("INF".PadLeft(7));
                }
                else
                {
                    Console.Write(dist[i, j].ToString().PadLeft(7));
                }
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int INF = int.MaxValue;

        int[,] graph = {
            { 0,   3,   10, 5 },
            { 2,   0,   INF, 4 },
            { INF, 1,   0,   INF },
            { 1, INF, 2,   0 }
        };

        Floyd fw = new Floyd(graph, 4);
        fw.Run();
    }
}


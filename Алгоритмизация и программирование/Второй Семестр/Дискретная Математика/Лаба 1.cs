using System;

//Лабараторная работа по дискретной математике №1 07.02.2025

class Program
{
    static int[,] a = {
        {0, 0, 1, 0, 1},
        {0, 0, 1, 1, 0},
        {1, 1, 0, 1, 0},
        {0, 1, 1, 0, 0},
        {1, 0, 0, 0, 0}
    };

    static int n = a.GetLength(0);
    static bool[] visited = new bool[n];
    static int count = 0;

    static void DFS(int node)
    {
        visited[node] = true;
        for (int i = 0; i < n; i++)
        {
            if (a[node, i] == 1 && !visited[i])
            {
                DFS(i);
            }
        }
    }

    static void Main()
    {
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                DFS(i);
                count++;
            }
        }

        Console.WriteLine("Количество элементов связанности: " + count);
    }
}

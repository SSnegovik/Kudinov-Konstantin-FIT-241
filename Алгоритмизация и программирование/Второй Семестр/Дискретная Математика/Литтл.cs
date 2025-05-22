using System;
using System.Collections.Generic;

class LittlesAlgorithm
{
    const int INF = int.MaxValue;

    class Result
    {
        public List<(int from, int to)> Path = new List<(int, int)>();
        public int Cost = 0;
    }

    static Result Solve(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        bool[,] used = new bool[n, n];
        List<(int, int)> rawPath = new List<(int, int)>();
        int totalCost = 0;

        while (rawPath.Count < n)
        {
            // Редукция строк
            for (int i = 0; i < n; i++)
            {
                int rowMin = INF;
                for (int j = 0; j < n; j++)
                    if (matrix[i, j] < rowMin)
                        rowMin = matrix[i, j];

                if (rowMin != INF && rowMin > 0)
                {
                    for (int j = 0; j < n; j++)
                        if (matrix[i, j] < INF)
                            matrix[i, j] -= rowMin;
                    totalCost += rowMin;
                }
            }

            // Редукция столбцов
            for (int j = 0; j < n; j++)
            {
                int colMin = INF;
                for (int i = 0; i < n; i++)
                    if (matrix[i, j] < colMin)
                        colMin = matrix[i, j];

                if (colMin != INF && colMin > 0)
                {
                    for (int i = 0; i < n; i++)
                        if (matrix[i, j] < INF)
                            matrix[i, j] -= colMin;
                    totalCost += colMin;
                }
            }

            // Выбор нуля с максимальным коэффициентом оценки
            int bestI = -1, bestJ = -1, maxkef = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 0 && !used[i, j])
                    {
                        int rowMin = INF, colMin = INF;

                        for (int k = 0; k < n; k++)
                            if (k != j)
                                rowMin = Math.Min(rowMin, matrix[i, k]);
                        for (int k = 0; k < n; k++)
                            if (k != i)
                                colMin = Math.Min(colMin, matrix[k, j]);

                        int kef = (rowMin == INF ? 0 : rowMin) + (colMin == INF ? 0 : colMin);
                        if (kef > maxkef)
                        {
                            maxkef = kef;
                            bestI = i;
                            bestJ = j;
                        }
                    }
                }
            }

            if (bestI == -1 || bestJ == -1)
                break;

            rawPath.Add((bestI, bestJ));

            matrix[bestJ, bestI] = INF;

            // Запретить всю строку и столбец
            for (int k = 0; k < n; k++)
            {
                matrix[bestI, k] = INF;
                matrix[k, bestJ] = INF;
            }

            used[bestI, bestJ] = true;
        }

        Dictionary<int, int> map = new Dictionary<int, int>();
        foreach (var p in rawPath)
            map[p.Item1] = p.Item2;

        List<(int, int)> finalPath = new List<(int, int)>();
        int start = 0;
        int current = start;
        do
        {
            int next = map[current];
            finalPath.Add((current, next));
            current = next;
        }
        while (current != start);

        return new Result { Path = finalPath, Cost = totalCost };
    }

    static void Main()
    {
        int[,] costMatrix = {
            { INF, 20, 30, 10 },
            { 15, INF, 16, 4 },
            { 3, 5, INF, 2 },
            { 19, 6, 18, INF }
        };

        var result = Solve((int[,])costMatrix.Clone());

        Console.WriteLine("Оптимальный маршрут:");
        foreach (var pair in result.Path)
            Console.WriteLine($"{pair.Item1 + 1} -> {pair.Item2 + 1}");


        Console.WriteLine($"Общая стоимость: {result.Cost}");
    }
}

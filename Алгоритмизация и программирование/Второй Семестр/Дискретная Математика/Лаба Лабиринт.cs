using System;
using System.Collections.Generic;

// Лабараторная работа по дискретной математике "Лабиринт" 28.03.2025

class Program
{
    // Направления для проверки соседних клеток (вверх, вниз, влево, вправо)
    static int[] dirX = { -1, 1, 0, 0 };
    static int[] dirY = { 0, 0, -1, 1 };

    static int BFS(int[,] maze, int startX, int startY, int endX, int endY)
    {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);
        
        if (maze[startX, startY] == 1 || maze[endX, endY] == 1)
        {
            Console.WriteLine("Невозможно начать или закончить путь (старт или финиш заблокированы).");
            return -1;
        }

        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(new Tuple<int, int>(startX, startY));

        int[,] steps = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                steps[i, j] = -1;
            }
        }

        steps[startX, startY] = 0;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int x = current.Item1;
            int y = current.Item2;

            if (x == endX && y == endY)
            {
                return steps[x, y];
            }
            
            for (int i = 0; i < 4; i++)
            {
                int newX = x + dirX[i];
                int newY = y + dirY[i];

                // Проверяем, не выходит ли клетка за пределы поля и не является ли она препятствием
                if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && maze[newX, newY] == 0 && steps[newX, newY] == -1)
                {
                    steps[newX, newY] = steps[x, y] + 1;
                    queue.Enqueue(new Tuple<int, int>(newX, newY));
                }
            }
        }

        return -1;
    }

    static void Main()
    {
        // Пример лабиринта (0 - свободная клетка, 1 - препятствие)
        int[,] maze = {
            { 0, 0, 1, 0, 1 },
            { 0, 1, 0, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 1, 0, 1, 0 }
        };

        int startX = 0, startY = 0;  // Начальная точка (1, 1)
        int endX = 4, endY = 4;      // Конечная точка (5, 5)

        int result = BFS(maze, startX, startY, endX, endY);

        if (result == -1)
        {
            Console.WriteLine("Невозможно достичь конечной точки.");
        }
        else
        {
            Console.WriteLine($"Минимальное количество шагов: {result}");
        }
    }
}


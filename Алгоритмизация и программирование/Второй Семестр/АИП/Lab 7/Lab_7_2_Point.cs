using System;

//Лабораторная работа 7_2 21.03.2025

public class Coordinate
{
    public double X { get; set; }
    public double Y { get; set; }

    public Coordinate(double x, double y)
    {
        X = x;
        Y = y;
    }
}

public class Zone
{
    public double Left { get; }
    public double Bottom { get; }
    public double Right { get; }
    public double Top { get; }

    public Zone(double left, double bottom, double right, double top)
    {
        Left = left;
        Bottom = bottom;
        Right = right;
        Top = top;
    }

    public bool Contains(Coordinate coord)
    {
        return coord.X >= Left && coord.X <= Right && coord.Y >= Bottom && coord.Y <= Top;
    }
}

public class Simulation
{
    private static Random random = new Random();

    public static void Main()
    {
        var border = new Zone(0, 0, 2, 2);
        var dot = new Coordinate(1, 1);

        Console.WriteLine($"Стартовые координаты: ({dot.X}, {dot.Y})");

        for (int step = 1; step <= 10; step++)
        {
            ShiftPosition(dot);
            Console.WriteLine($"Положение после шага {step}: ({dot.X:F2}, {dot.Y:F2})");

            if (!border.Contains(dot))
            {
                Console.WriteLine("Точка вышла за границы зоны!");
                break;
            }
        }
    }

    private static void ShiftPosition(Coordinate dot)
    {
        double shiftX = random.NextDouble() * 2 - 1; // от -1 до 1
        double shiftY = random.NextDouble() * 2 - 1;

        dot.X += shiftX;
        dot.Y += shiftY;
    }
}
        

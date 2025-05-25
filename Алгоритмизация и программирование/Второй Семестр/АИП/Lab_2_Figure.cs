using System;

//Лабараторная работа 2 14.02.2025

public abstract class GeometricFigure
{
    public string Title { get; set; }

    protected GeometricFigure(string title)
    {
        Title = title;
    }

    public abstract double GetPerimeter();
    public abstract double GetArea();
}

public class CircleFigure : GeometricFigure
{
    public double Radius { get; set; }

    public CircleFigure(string title, double radius) : base(title)
    {
        Radius = radius;
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public override double GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}

public class SquareFigure : GeometricFigure
{
    public double Side { get; set; }

    public SquareFigure(string title, double sideLength) : base(title)
    {
        Side = sideLength;
    }

    public override double GetPerimeter()
    {
        return 4 * Side;
    }

    public override double GetArea()
    {
        return Side * Side;
    }
}

public class EquilateralTriangle : GeometricFigure
{
    public double Side { get; set; }

    public EquilateralTriangle(string title, double sideLength) : base(title)
    {
        Side = sideLength;
    }

    public override double GetPerimeter()
    {
        return 3 * Side;
    }

    public override double GetArea()
    {
        return (Math.Sqrt(3) / 4) * Side * Side;
    }
}

public class App
{
    public static void Main()
    {
        var circle = new CircleFigure("Окружность", 5.0);
        var square = new SquareFigure("Квадрат", 4.0);
        var triangle = new EquilateralTriangle("Равносторонний треугольник", 5.0);

        DisplayInfo(circle);
        DisplayInfo(square);
        DisplayInfo(triangle);
    }

    static void DisplayInfo(GeometricFigure figure)
    {
        Console.WriteLine($"Фигура: {figure.Title}, Периметр: {figure.GetPerimeter():F2}, Площадь: {figure.GetArea():F2}");
    }
}


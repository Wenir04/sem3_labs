using System;
using System.Drawing;
using System.Reflection.Metadata;

public class Point
{
    private int x;
    private int y;

    public int X
    {
        get { return x; }
    }

    public int Y
    {
        get { return y; }
    }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

public class Figure
{
    private Point[] points;
    public string Name { get; set; }

    public Figure(Point p1, Point p2, Point p3)
    {
        points = new Point[] { p1, p2, p3 };
    }

    public Figure(Point p1, Point p2, Point p3, Point p4)
    {
        points = new Point[] { p1, p2, p3, p4 };
    }

    public Figure(Point p1, Point p2, Point p3, Point p4, Point p5)
    {
        points = new Point[] { p1, p2, p3, p4, p5 };
    }

    public double LengthSide(Point A, Point B)
    {
        int dx = A.X - B.X;
        int dy = A.Y - B.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public double PerimeterCalculator()
    {
        double perimeter = 0;
        for (int i = 0; i < points.Length - 1; i++)
        {
            perimeter += LengthSide(points[i], points[i + 1]);
        }
        perimeter += LengthSide(points[points.Length - 1], points[0]);
        return perimeter;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Point p1 = new Point(0, 0);
        Point p2 = new Point(1, 0);
        Point p3 = new Point(0, 1);
        Point p4 = new Point(1, 1);
        Point p5 = new Point(2, 2);

        Figure triangle = new Figure(p1, p2, p3);
        triangle.Name = "Треугольник";
        double trianglePerimeter = triangle.PerimeterCalculator();

        Console.WriteLine("Figure: " + triangle.Name);
        Console.WriteLine("Perimeter: " + trianglePerimeter);


        Figure rectangle = new Figure(p1, p2, p3, p4);
        rectangle.Name = "Четырёхугольник";
        double rectanglePerimeter = rectangle.PerimeterCalculator();

        Console.WriteLine("Figure: " + rectangle.Name);
        Console.WriteLine("Perimeter: " + rectanglePerimeter);


        Figure pentagon = new Figure(p1, p2, p3, p4,p5);
        pentagon.Name = "Пятиугольник";
        double pentagonPerimeter = pentagon.PerimeterCalculator();

        Console.WriteLine("Figure: " + pentagon.Name);
        Console.WriteLine("Perimeter: " + pentagonPerimeter);

        Console.ReadLine();
    }
}
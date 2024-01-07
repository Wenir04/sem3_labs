using System;

public class Rectangle
{
    private double side1;
    private double side2;

    public Rectangle(double sideA, double sideB)
    {
        side1 = sideA;
        side2 = sideB;
    }

    private double CalculateArea()
    {
        return side1 * side2;
    }

    private double CalculatePerimeter()
    {
        return 2 * (side1 + side2);
    }

    public double Area
    {
        get { return CalculateArea(); }
    }

    public double Perimeter
    {
        get { return CalculatePerimeter(); }
    }
}

public class rectangle
{
    public static void Main()
    {
        Console.WriteLine("Введите длину первой стороны: ");
        double sideA = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите длину второй стороны: ");
        double sideB = double.Parse(Console.ReadLine());

        Rectangle rectangle = new Rectangle(sideA, sideB);
        Console.WriteLine("Площадь прямоугольника: " + rectangle.Area);
        Console.WriteLine("Периметр прямоугольника: " + rectangle.Perimeter);
    }
}
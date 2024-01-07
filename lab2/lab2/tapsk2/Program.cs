using System;
public class Vehicle
{
    private double[] Coordinates { get; }
    private int Cost { get; }
    private int Speed { get; }
    private int Year { get; }

    protected Vehicle(double[] coordinates, int cost, int speed, int year)
    {
        if (coordinates.Length != 2)
        {
            throw new ArgumentException("Argument coordinates must contain 2 numbers in list");
        }
        this.Coordinates = coordinates;
        this.Cost = cost;
        this.Speed = speed;
        this.Year = year;
    }

    public virtual void Print()
    {
        Console.WriteLine($"coordinates: {Coordinates[0]}, {Coordinates[1]}\ncost: {Cost}\nspeed: {Speed}\nyear of manufacture: {Year}");
    }
}

public class Car : Vehicle
{
    public Car(double[] coordinates, int speed, int cost, int year) : base(coordinates, speed, cost, year) { }

    public override void Print()
    {
        Console.WriteLine("Type: Car");
        base.Print();
        Console.WriteLine("---------------------------------");
    }
}

public class Plane : Vehicle
{
    private int Height { get; }
    private int NOPass { get; }

    public Plane(double[] coordinates, int height, int cost, int speed, int year, int nOPass) : base(coordinates, cost, speed,
        year)
    {
        this.Height = height;
        this.NOPass = nOPass;
    }

    public override void Print()
    {
        Console.WriteLine("Type: Plane");
        base.Print();
        Console.WriteLine($"flight height: {Height}\nnumber of passengers: {NOPass}");
        Console.WriteLine("---------------------------------");
    }
}

public class Ship : Vehicle
{
    private string Reg { get; }
    private int NOPass { get; }

    public Ship(double[] coordinates, int cost, int speed, int year, string registry, int nOPass) : base(coordinates, cost,
        speed, year)
    {
        this.Reg = registry;
        this.NOPass = nOPass;
    }

    public override void Print()
    {
        Console.WriteLine("Type: Ship");
        base.Print();
        Console.WriteLine($"port of registry: {Reg}\nnumber of passengers: {NOPass}");
        Console.WriteLine("---------------------------------");
    }
}


class Program
{
    public static void Main()
    {
        double[] CoordinatesForCar = new[] { 74.0, 28.0 };
        double[] CoordinatesForShip = new[] { 94.0, 77.8 };
        double[] CoordinatesForPlane = new[] { 752.4, 476.0 };

        Car car = new Car(CoordinatesForCar, 250, 50000, 2016);
        Ship ship = new Ship(CoordinatesForShip, 1000000, 85, 2010, "Стамбул", 250);
        Plane plane = new Plane(CoordinatesForPlane, 5000, 3500000, 850, 2020, 150);

        car.Print();
        ship.Print();
        plane.Print();
    }
}
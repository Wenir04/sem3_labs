public class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }

    public Car()
    {
        this.Name = "";
    }

    public Car(string name, int year, int max_speed)
    {
        this.Name = name;
        this.ProductionYear = year;
        this.MaxSpeed = max_speed;
    }

    public void Print()
    {
        Console.WriteLine($"{Name}, {ProductionYear}, {MaxSpeed}");
    }
}

public class CarComparer : IComparer<Car>
{
    private string _option;

    public CarComparer(string option)
    {
        this._option = option;
    }

    public int Compare(Car car1, Car car2)
    {
        if (_option == "name")
        {
            return string.Compare(car1.Name, car2.Name);
        }
        else if (_option == "year")
        {
            return car1.ProductionYear.CompareTo(car2.ProductionYear);
        }
        else if (_option == "maxspeed")
        {
            return car1.MaxSpeed.CompareTo(car2.MaxSpeed);
        }

        throw new ArgumentException("Invalid sort option");
    }
}

class Program
{
    public static int Main()
    {
        Car[] cars = new[]
        {
            new Car("BMW", 2015, 295),
            new Car("Mercedes", 2018, 290),
            new Car("Audi", 2020, 250)
        };
        Console.WriteLine("Sorting by name:");
        Array.Sort(cars, new CarComparer("name"));
        printCars(cars);

        Console.WriteLine("\nSorting by production year:");
        Array.Sort(cars, new CarComparer("year"));
        printCars(cars);

        Console.WriteLine("\nSorting by max speed:");
        Array.Sort(cars, new CarComparer("maxspeed"));
        printCars(cars);
        return 0;
    }

    public static void printCars(Car[] cars)
    {
        foreach (Car car in cars)
        {
            car.Print();
        }
    }
}

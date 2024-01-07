public class CarsCatalog
{
    private List<Car> Cars = new List<Car>();

    public List<Car> cars
    {
        get { return Cars; }
    }

    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < Cars.Count)
                return $"{Cars[index].name} - {Cars[index].engine}";

            return null;
        }
    }

    public void AddCar(Car car)
    {
        Cars.Add(car);
    }

    public void RemoveCar(Car car)
    {
        Cars.Remove(car);
    }
}


public class Car : IEquatable<Car>
{
    private string Name;
    private string Engine;
    private int MaxSpeed;

    public string name
    {
        get { return this.Name; }
    }

    public string engine
    {
        get { return this.Engine; }
    }

    public Car(string name, string engine, int maxSpeed)
    {
        this.Name = name;
        this.Engine = engine;
        this.MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return Name;
    }


    public bool Equals(Car other)
    {
        if (other == null)
            return false;

        return this.Name == other.Name && this.Engine == other.Engine && this.MaxSpeed == other.MaxSpeed;
    }

    public override bool Equals(object obj)
    {5
        if (obj == null || !(obj is Car))
            return false;

        return Equals((Car)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() ^ Engine.GetHashCode() ^ MaxSpeed.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        Car car1 = new Car("BMW", "V8", 250);
        Car car2 = new Car("Audi", "V6", 220);
        Car car3 = new Car("Mercedes", "V12", 300);

        CarsCatalog catalog = new CarsCatalog();
        catalog.AddCar(car1);
        catalog.AddCar(car2);
        catalog.AddCar(car3);

        Console.WriteLine("Cars in the catalog:");
        for (int i = 0; i < catalog.cars.Count; i++)
        {
            Console.WriteLine($"Car {i + 1}: {catalog[i]}");
        }

        catalog.RemoveCar(car2);

        Console.WriteLine("\nAfter removing a car from the catalog:");
        for (int i = 0; i < catalog.cars.Count; i++)
        {
            Console.WriteLine($"Car {i + 1}: {catalog[i]}");
        }

    }
}
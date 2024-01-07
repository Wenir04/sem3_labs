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
public class CarCatalog
{
    private Car[] _arr;
    private byte _mode = 0;
    public CarCatalog(Car[] _arr) => this._arr = _arr;
    public byte Mode { set { this._mode = value; } }
    public int Length => _arr.Length;

    public IEnumerator<Car> GetEnumerator()
    {
        switch (_mode)
        {
            case 0:
                for (int i = 0; i < _arr.Length; ++i)
                {
                    yield return _arr[i];
                }

                break;
            case 1:
                for (int i = (_arr.Length - 1); i > -1; --i)
                {
                    yield return _arr[i];
                }

                break;
        }
    }

    public IEnumerable<Car> GetPersonnel(int param, byte mode)
    {
        switch (mode)
        {
            case 0:
                for (int i = 0; i < _arr.Length; ++i)
                {
                    if (_arr[i].ProductionYear == param)
                        yield return _arr[i];
                }

                break;
            case 1:
                for (int i = 0; i < _arr.Length; ++i)
                {
                    if ((_arr[i].MaxSpeed == param))
                        yield return _arr[i];
                }

                break;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Car[] arr =
        {
            new Car("Citroen", 2013, 186),
            new Car("Honda", 2011, 190),
            new Car("Toyota", 2008, 185),
            new Car("Subaru", 2008, 195)
        };
        CarCatalog catalog = new(arr);
        catalog.Mode = 0;
        Console.WriteLine("Forward:");
        foreach (Car car in catalog)
        {
            car.Print();
        }
        Console.WriteLine();

        Console.WriteLine("Reverse:");
        catalog.Mode = 1;
        foreach (Car car in catalog)
        {
            car.Print();
        }
        Console.WriteLine();

        Console.WriteLine("Filtering by year(2013):");
        foreach (Car car in catalog.GetPersonnel(2013, 0))
        {
            car.Print();
        }
        Console.WriteLine();

        Console.WriteLine("Filtering by max speed(190):");
        foreach (Car car in catalog.GetPersonnel(190, 1))
        {
            car.Print();
        }


    }
}
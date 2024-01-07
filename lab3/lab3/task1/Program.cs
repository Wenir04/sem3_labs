public struct Vector
{
    private int X;
    private int Y;
    private int Z;

    public Vector(int x, int y, int z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    public static int operator *(Vector v1, Vector v2)
    {
        return (v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z);
    }

    public static Vector operator *(Vector v, int a)
    {
        return new Vector(v.X * a, v.Y * a, v.Z * a);
    }

    public double Length()
    {
        return Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
    }

    public static bool operator <(Vector v1, Vector v2)
    {
        return v1.Length() < v2.Length();
    }

    public static bool operator >(Vector v1, Vector v2)
    {
        return v1.Length() > v2.Length();
    }

    public static bool operator ==(Vector v1, Vector v2)
    {
        return (v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z);
    }

    public static bool operator !=(Vector v1, Vector v2)
    {
        return (v1.X != v2.X && v1.Y != v2.Y && v1.Z != v2.Z);
    }

    public void Print()
    {
        Console.WriteLine("{" + this.X + ", " + this.Y + ", " + this.Z + "}\n");
    }
}


class Program
{
    public static void Main()
    {
        Vector v1 = new Vector(1, 2, 3);
        Vector v2 = new Vector(3, 4, 5);
        Vector v3 = v1;

        Console.WriteLine("v1");
        v1.Print();
        Console.WriteLine("v1_length = " + v1.Length());
        Console.WriteLine("v2");
        v2.Print();
        Console.WriteLine("v2_length = " + v2.Length());

        Vector summ = v1 + v2;
        Console.WriteLine("v1 + v2 = ");
        summ.Print();

        Console.WriteLine($" v1 * 10 = ");
        (v1 * 10).Print();

        Console.WriteLine("v1 * v2 = " + v1 * v2);

    }
}
public class MyList<T>
{
    private T[] _array;
    private int _size;
    private int _version;

    public MyList()
    {
        this._array = new T[] { };
        this._size = 0;
        this._version = 1;
    }

    public MyList(params T[] array)
    {
        this._array = array;
        this._size = array.Length;
        this._version = 1;
    }

    public MyList(int size)
    {
        this._array = new T[] { };
        this._size = size;
        this._version = 1;
    }

    public T this[int index]
    {
        get { return _array[index]; }
        set { this._array[index] = value; }
    }

    public int Length
    {
        get { return this._size; }
    }

    public void AddElem(T new_elem)
    {
        T[] new_arr = new T[this._size * 2];
        this._version++;
        this._array.CopyTo(new_arr, 0);
        new_arr[this._size] = new_elem;
        this._array = new_arr;
        this._size++;

    }

    public void Print()
    {
        for (int i = 0; i < this._size; i++)
        {
            Console.Write(this._array[i] + " ");
        }
        Console.Write("\n");
    }
}

class Program
{
    public static void Main()
    {
        MyList<int> ml1 = new(1, 2, 3, 4);

        ml1.AddElem(5);
        ml1.Print();

    }
}

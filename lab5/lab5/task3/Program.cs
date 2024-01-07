public class MyDictionary<TKey, TValue>
{
    private Entry<TKey, TValue>[]? _entries;
    private int _count;

    int Count
    {
        get { return _count; }
    }

    public MyDictionary()
    {
        this._entries = new Entry<TKey, TValue>[] { };
        this._count = 0;
    }

    public MyDictionary(params Entry<TKey, TValue>[] elems)
    {
        this._entries = elems;
        _count = elems.Length;
    }

    public void Add(TKey key, TValue value)
    {
        bool added = false;
        Entry<TKey, TValue>[] n_entries = new Entry<TKey, TValue>[_count + 1];

        for (int i = 0; i < _count; i++)
        {
            if (EqualityComparer<TKey>.Default.Equals(_entries[i].Key, key))
            {
                _entries[i].Value = value;
                n_entries[i] = _entries[i];
                added = true;
            }
            else
            {
                n_entries[i] = _entries[i];
            }
        }

        if (!added)
        {
            n_entries[_count] = new Entry<TKey, TValue>(key, value);
            _count++;
        }
        _entries = n_entries;
    }

    public TValue this[TKey key]
    {
        get
        {
            foreach (var item in _entries)
            {
                if (EqualityComparer<TKey>.Default.Equals(item.Key, key))
                {
                    return item.Value;
                }
            }
            throw new KeyNotFoundException("Key does not exist.");
        }
    }

    public IEnumerator<Entry<TKey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return new Entry<TKey, TValue>(_entries[i].Key, _entries[i].Value);
        }
    }

    public void Print()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine($"[{entry.Key}] : {entry.Value}");
        }
        Console.WriteLine();
    }
}

public struct Entry<TKey, TValue>
{
    private TKey _key;
    private TValue _value;

    public Entry(TKey key, TValue value)
    {
        this._key = key;
        this._value = value;
    }

    public TValue Value
    {
        get { return _value; }
        set { _value = value; }
    }
    public TKey Key => _key;

    public void Print()
    {
        Console.WriteLine($"[{_key}] : {_value}");
    }
}

class Program
{
    public static void Main()
    {
        MyDictionary<int, int> dic = new MyDictionary<int, int>();
        dic.Add(1, 5);
        dic.Add(2, 9);
        dic.Print();
        dic.Add(2, 4);

        foreach (var d in dic)
        {
            d.Print();
        }
    }
}

public class Currency
{
    private double _value;

    public double value
    {
        get { return _value; }

        set { _value = value; }
    }

    public Currency()
    {
        this._value = 0;
    }

    public Currency(double value)
    {
        this._value = value;
    }

    public virtual void print()
    {
        Console.WriteLine(_value);
    }
}


class CurrencyEUR : Currency
{
    public CurrencyEUR(double value) : base(value) { }

    public CurrencyEUR(Currency def)
    {
        this.value = def.value;
    }

    public static implicit operator CurrencyEUR(CurrencyRUB rub)
    {
        double val = rub.value / 80;
        return new CurrencyEUR(val);
    }

    public static implicit operator CurrencyEUR(CurrencyUSD usd)
    {
        double val = usd.value * 0.75;
        return new CurrencyEUR(val);
    }

    public override void print()
    {
        Console.WriteLine($"{value} eur");
    }
}

class CurrencyRUB : Currency
{
    public CurrencyRUB(Currency def)
    {
        this.value = def.value;
    }

    public CurrencyRUB(double value) : base(value) { }

    public static implicit operator CurrencyRUB(CurrencyUSD usd)
    {
        double val = usd.value * 60;
        return new CurrencyRUB(val);
    }

    public static implicit operator CurrencyRUB(CurrencyEUR eur)
    {
        double val = eur.value * 80;
        return new CurrencyRUB(val);
    }

    public override void print()
    {
        Console.WriteLine($"{value} rub");
    }
}

class CurrencyUSD : Currency
{
    public CurrencyUSD(Currency def)
    {
        this.value = def.value;
    }

    public CurrencyUSD(double value) : base(value) { }

    public static implicit operator CurrencyUSD(CurrencyRUB rub)
    {
        double val = rub.value / 60;
        return new CurrencyUSD(val);
    }

    public static implicit operator CurrencyUSD(CurrencyEUR eur)
    {
        double val = eur.value / 0.75;
        return new CurrencyUSD(val);
    }

    public override void print()
    {
        Console.WriteLine($"{value} usd");
    }
}
class Program
{
    static int Main()
    {
        Currency cur = new Currency(150.0);
        CurrencyRUB cur_rub1 = new CurrencyRUB(cur);
        cur_rub1.print();
        CurrencyUSD cur_usd = cur_rub1;
        cur_usd.print();
        CurrencyEUR cur_eur = cur_usd;
        cur_eur.print();
        CurrencyRUB cur_rub2 = cur_eur;
        cur_rub2.print();

        return 0;
    }
}
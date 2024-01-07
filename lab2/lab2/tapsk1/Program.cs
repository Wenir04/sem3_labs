using System;
using System.Runtime.InteropServices;
public class Pupil
{
    public virtual void Study()
    {
        Console.WriteLine("Pupil is studying\n");
    }

    public virtual void Read()
    {
        Console.WriteLine($"Pupil is reading\n");
    }

    public virtual void Write()
    {
        Console.WriteLine($"Pupil is writing\n");
    }

    public void Relax()
    {
        Console.WriteLine($"Pupil is relaxing\n");
    }
}


public class ExcellentPupil : Pupil
{
    public override void Study()
    {
        Console.WriteLine("Pupil is studying excellently");
    }

    public override void Read()
    {
        Console.WriteLine("Pupil is reading excellently");
    }

    public override void Write()
    {
        Console.WriteLine("Pupil is writing excellently");
    }
}

public class GoodPupil : Pupil
{
    public override void Study()
    {
        Console.WriteLine("Pupil is studying good");
    }

    public override void Read()
    {
        Console.WriteLine("Pupil is reading good");
    }

    public override void Write()
    {
        Console.WriteLine("Pupil is writing good");
    }
}

public class BadPupil : Pupil
{
    public override void Study()
    {
        Console.WriteLine("Pupil is studying badly");
    }

    public override void Read()
    {
        Console.WriteLine("Pupil is reading badly");
    }

    public override void Write()
    {
        Console.WriteLine("Pupil is writing badly");
    }
}
public class ClassRoom
{
    private Pupil[] _pupils;

    public ClassRoom(params Pupil[] pupils)
    {
        if (pupils.Length != 4)
        {
            throw new ArgumentException("Number of pupils in classroom must be 4");
        }
        else { this._pupils = pupils; }
    }

    public void print()
    {
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"Pupil {i + 1}:\n");
            _pupils[i].Study();
            _pupils[i].Read();
            _pupils[i].Write();
            _pupils[i].Relax();
        }
    }
}


public class Program
{
    static void Main()
    {
        Pupil p1 = new BadPupil();
        Pupil p2 = new GoodPupil();
        Pupil p3 = new ExcellentPupil();
        Pupil p4 = new GoodPupil();

        Pupil[] pupils = new[] { p1, p2, p3, p4 };

        ClassRoom cr = new ClassRoom(pupils);

        cr.print();
    }
}
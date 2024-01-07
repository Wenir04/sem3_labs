using System.Xml;
using System.Reflection;
using System.Xml.Serialization;

namespace AnimalClasses;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
public class CommentAttribute : Attribute
{
    public string Comment { get; }

    public CommentAttribute(string comment)
    {
        Comment = comment;
    }
}

[Comment("Types of animals enumeration")]
public enum eClassificationAnimal
{
    Herbivores,
    Carnivores,
    Omnivores
}

[Comment("Favorite food enumeration")]
public enum eFavoriteFood
{
    Meat,
    Plants,
    Everything
}

[Comment("Abstract class for creating animals")]
public abstract class Animal
{
    public string? Country { get; set; }
    public bool HideFromOtherAnimals { get; set; }
    public string? Name { get; set; }
    private eClassificationAnimal Classification { get; set; }

    // constructors
    protected Animal(string country, bool hideFromOtherAnimals, string name, eClassificationAnimal classification)
    {
        this.Country = country;
        this.HideFromOtherAnimals = hideFromOtherAnimals;
        this.Name = name;
        this.Classification = classification;

    }

    protected Animal()
    {
        this.Country = "";
        this.HideFromOtherAnimals = false;
        this.Name = "";
        this.Classification = eClassificationAnimal.Omnivores;
    }

    // deconstructor
    public void Deconstruct(out string country, out bool hideFromOtherAnimals, out string name,
        out eClassificationAnimal classification)
    {
        country = Country;
        hideFromOtherAnimals = HideFromOtherAnimals;
        name = Name;
        classification = Classification;
    }

    public eClassificationAnimal GetClassificationAnimal
    {
        get { return Classification; }
        set { Classification = value; }
    }

    // abstract methods
    public abstract eFavoriteFood GetFavoriteFood();
    public abstract void SayHello();

}

[Comment("Class for cow")]
public class Cow : Animal
{
    public override eFavoriteFood GetFavoriteFood()
    {
        return eFavoriteFood.Plants;
    }

    public override void SayHello()
    {
        Console.WriteLine("MUUU");
    }
}

[Comment("Class for lion")]
class Lion : Animal
{
    public override eFavoriteFood GetFavoriteFood()
    {
        return eFavoriteFood.Meat;
    }

    public override void SayHello()
    {
        Console.WriteLine("RRRR");
    }
}
[Comment("Class for pig")]
class Pig : Animal
{
    public override eFavoriteFood GetFavoriteFood()
    {
        return eFavoriteFood.Everything;
    }

    public override void SayHello()
    {
        Console.WriteLine("UI");
    }
}

class Program
{
    static void Main()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Cow));
        string filePath = @"C:\Users\kolob\OneDrive\Рабочий стол\sem3\laba8\animall.xml";
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            Animal? cow = xmlSerializer.Deserialize(fs) as Cow;
            Console.WriteLine($"Country: {cow?.Country}\nHide from other animals: {cow?.HideFromOtherAnimals}\n" +
                              $"Name: {cow?.Name}\nClassification: {cow?.GetClassificationAnimal}");
        }
    }
}
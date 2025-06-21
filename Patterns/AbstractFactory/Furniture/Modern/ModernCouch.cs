namespace Patterns.AbstractFactory.Furniture.Modern;

public class ModernCouch : ICouch
{
    public void SitOn()
    {
        Console.WriteLine("You are sitting on a Modern Couch");
    }

    public void LayOn()
    {
        Console.WriteLine("You are laying on a Modern Couch");
    }
}
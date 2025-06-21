namespace Patterns.AbstractFactory.Furniture;

public interface IChair
{
    void SitOn()
    {
        Console.WriteLine("You are sitting on an unremarkable chair");
    }
}
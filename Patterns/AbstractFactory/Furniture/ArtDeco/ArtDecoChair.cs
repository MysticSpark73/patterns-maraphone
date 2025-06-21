namespace Patterns.AbstractFactory.Furniture.ArtDeco;

public class ArtDecoChair : IChair
{
    public void SitOn()
    {
        Console.WriteLine("You are sitting on an Art Deco chair");
    }
}
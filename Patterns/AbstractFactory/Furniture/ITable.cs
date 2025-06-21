namespace Patterns.AbstractFactory.Furniture;

public interface ITable
{
    void PutOn(string[] objects)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            Console.WriteLine($"You put a {objects[i]} onto an unremarkable table");
        }
    }
}
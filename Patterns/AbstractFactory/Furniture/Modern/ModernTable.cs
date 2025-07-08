using System;

namespace Patterns.AbstractFactory.Furniture.Modern;

public class ModernTable : ITable
{
    public void PutOn(string[] objects)
    {
        if (objects.Length == 0) return;

        for (int i = 0; i < objects.Length; i++)
        {
            Console.WriteLine($"You put a {objects[i]} onto a Modern Table");
        }
    }
}
using System;

namespace Patterns.AbstractFactory.Furniture.Victorian;

public class VictorianTable : ITable
{
    public void PutOn(string[] objects)
    {
        if (objects.Length == 0) return;

        for (int i = 0; i < objects.Length; i++)
        {
            Console.WriteLine($"You put a {objects[i]} onto a Victorian table");
        }
    }
}
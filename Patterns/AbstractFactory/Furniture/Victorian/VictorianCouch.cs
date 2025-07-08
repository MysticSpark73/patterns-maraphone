using System;

namespace Patterns.AbstractFactory.Furniture.Victorian;

public class VictorianCouch : ICouch
{
    public void SitOn()
    {
        Console.WriteLine("You are sitting on a Victorian couch");
    }

    public void LayOn()
    {
        Console.WriteLine("You are lying on a Victorian couch");
    }
}
using System;

namespace Patterns.AbstractFactory.Furniture;

public interface ICouch
{
    void SitOn()
    {
        Console.WriteLine("You are sitting on an unremarkable couch");
    }

    void LayOn()
    {
        Console.WriteLine("You are lying on an unremarkable couch");
    }
}
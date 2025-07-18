using System;
using Patterns.Prototype.Interfaces;

namespace Patterns.Prototype.Organelles;

public class Ribosome : Organelle, ICloneable<Ribosome>
{
    public void SynthesizeProtein()
    {
        Console.WriteLine("Ribosome produced protein");
    }

    public Ribosome Clone()
    {
        return new Ribosome();
    }
}
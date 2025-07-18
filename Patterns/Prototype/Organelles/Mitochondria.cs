using System;
using Patterns.Prototype.Interfaces;

namespace Patterns.Prototype.Organelles;

public class Mitochondria : Organelle, ICloneable<Mitochondria>
{
    private readonly int _maxEnergyLevel = 100;

    private int _energyLevel;

    public Mitochondria(int energyLevel = 0)
    {
        _energyLevel = energyLevel;
    }

    public override void UpdateState()
    {
        _energyLevel = (int) MathF.Min(_energyLevel + 1, _maxEnergyLevel);
    }

    public override Mitochondria Clone()
    {
        _energyLevel = (int) MathF.Round(_energyLevel / 2f);
        return new Mitochondria(_energyLevel);
    }
}
using Patterns.Prototype.Enums;
using Patterns.Prototype.Interfaces;
using Patterns.Prototype.Organelles;

namespace Patterns.Prototype.Cell;

public class Cell : ICloneable<Cell>
{
    private string _name;
    private CellType _type;
    private Organelle[] _organelles;
    private float _energyLevel;

    public Cell(string name, CellType type, Organelle[] organelles, float energyLevel)
    {
        _name = name;
        _type = type;
        _organelles = organelles;
        _energyLevel = energyLevel;
    }

    public Cell Clone()
    {
        return new Cell(_name, _type, _organelles, 100);
    }
}
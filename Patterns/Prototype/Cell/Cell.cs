using System.Threading;
using System.Threading.Tasks;
using Patterns.Prototype.Enums;
using Patterns.Prototype.Interfaces;
using Patterns.Prototype.Organelles;

namespace Patterns.Prototype.Cell;

public class Cell : ICloneable<Cell>
{
    private string _name;
    private CellType _type;
    private Organelle[] _organelles;
    private float EnergyLevel => GetEnergyLevelValue();

    private readonly int _energyLevelToDivide = 100;
    
    private CancellationTokenSource _cancellationTokenSource;

    public Cell(string name, CellType type, Organelle[] organelles)
    {
        _name = name;
        _type = type;
        _organelles = organelles;
        _cancellationTokenSource = new CancellationTokenSource();
    }

    public Cell Clone()
    {
        return new Cell(_name, _type, _organelles);
    }

    private async void UpdateState()
    {
        //todo: figure out how to run update loop indefinitely without blocking the thread
        //todo: possible solution instead of using Tasks set a big amount of tick iterations
        while (EnergyLevel > 0)
        {
            foreach (Organelle organelle in _organelles)
            {
                organelle.UpdateState();
            }

            if (EnergyLevel >= _energyLevelToDivide)
            {
                //todo: request divide
            }
            await Task.Delay(100);
        }
    }

    private int GetEnergyLevelValue()
    {
        int sum = 0;
        foreach (var organelle in _organelles)
        {
            sum += organelle.GetEnergyLevel();
        }

        return sum;
    }
}
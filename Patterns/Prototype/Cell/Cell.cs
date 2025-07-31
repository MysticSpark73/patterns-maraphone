using System;
using Patterns.Prototype.Enums;
using Patterns.Prototype.Interfaces;
using Patterns.Prototype.Organelles;

namespace Patterns.Prototype.Cell
{
    public class Cell : ICloneable<Cell>
    {
        public Action<Cell> RequestDivision;
        public string Name => _name;
    
        private string _name;
        private CellType _type;
        private Organelle[] _organelles;
        private float EnergyLevel => GetEnergyLevelValue();

        private readonly int _energyLevelToDivide = 100;
    
        public Cell(string name, CellType type, Organelle[] organelles)
        {
            _name = name;
            _type = type;
            _organelles = organelles;
        }

        public Cell Clone()
        {
            return new Cell(_name, _type, CloneOrganelles());
        }

        public void UpdateState()
        {
            if (EnergyLevel > 0)
            {
                foreach (Organelle organelle in _organelles)
                {
                    organelle.UpdateState();
                }

                if (EnergyLevel >= _energyLevelToDivide)
                {
                    RequestDivision?.Invoke(this);
                }
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

        private Organelle[] CloneOrganelles()
        {
            Organelle[] clonedOrganelles = new Organelle[_organelles.Length];
            for (int i = 0; i < _organelles.Length; i++)
            {
                clonedOrganelles[i] = _organelles[i].Clone();
            }

            return clonedOrganelles;
        }
    }
}
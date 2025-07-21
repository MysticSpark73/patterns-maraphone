using System;
using System.Collections.Generic;
using Patterns.Common;
using Patterns.Prototype.Data;
using Patterns.Prototype.Factory;

namespace Patterns.Prototype
{
    public class PrototypeMain : IProgram
    {
        private readonly int _cellUpdateIterations = 1000;

        private List<Cell.Cell> _cells = new List<Cell.Cell>();
    
        private CellAbstractFactory _cellAbstractFactory;
        private CellFactory _currentCellFactory;

        public void Run(object[]? args = null)
        {
            BuildCellFactory();
            TryGetArgsData(args, out var cellDataType);
            GetCellFactory(cellDataType);
            GenerateCells(10);
            SimulateCellsLifeCycle();
        }

        private void BuildCellFactory()
        {
            _cellAbstractFactory = new CellAbstractFactory();
        }

        private void GetCellFactory(CellDataType dataType)
        {
            _currentCellFactory = _cellAbstractFactory.CreateFactory(dataType);
        }

        private bool TryGetArgsData(object[]? args, out CellDataType cellDataType)
        {
            cellDataType = CellDataType.Eukaryotic;
            if (args == null) return false;
            if (args[0] is not string) return false;
            if (Enum.TryParse(args[0] as string, out cellDataType))
            {
                return true;
            }

            return false;
        }

        private void GenerateCells(int cellsCount)
        {
            Cell.Cell tmpCell;
            for (int i = 0; i < cellsCount; i++)
            {
                tmpCell = _currentCellFactory.Create();
                tmpCell.RequestDivision += OnDivisionRequested;
                _cells.Add(tmpCell);
            }
        }

        private void SimulateCellsLifeCycle()
        {
            for (int i = 0; i < _cellUpdateIterations; i++)
            {
                foreach (var cell in _cells)
                {
                    cell.UpdateState();
                }
            }
        }

        private void OnDivisionRequested(Cell.Cell cell)
        {
            _cells.Add(cell.Clone());
        }

        ~PrototypeMain()
        {
            foreach (var cell in _cells)
            {
                cell.RequestDivision -= OnDivisionRequested;
            }
        }
    }
}
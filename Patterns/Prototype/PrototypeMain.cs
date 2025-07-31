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
        private List<Cell.Cell> _bufferCells = new List<Cell.Cell>();
        private int _divisionsCount;

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
            if (Enum.TryParse(args[0] as string, out cellDataType)) return true;

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
            Console.WriteLine("Start simulating lifecycle");
            for (int i = 0; i < _cellUpdateIterations; i++)
            {
                Console.WriteLine($"Iteration {i}");
                ConcatBufferCells();
                
                foreach (var cell in _cells)
                {
                    cell.UpdateState();
                }
            }
            Console.WriteLine("Finished simulating Lifecycle");
            Console.WriteLine($"Total cell divisions = {_divisionsCount}");
        }

        private void OnDivisionRequested(Cell.Cell cell)
        {
            _divisionsCount++;
            _bufferCells.Add(cell.Clone());
        }

        private void ConcatBufferCells()
        {
            if (_bufferCells.Count == 0) return;
            _cells.AddRange(_bufferCells);
            _bufferCells.Clear();
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
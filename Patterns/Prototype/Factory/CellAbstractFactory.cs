using System;
using Patterns.Prototype.Data;

namespace Patterns.Prototype.Factory;

public class CellAbstractFactory
{
    public CellFactory CreateFactory(CellDataType cellDataType) => cellDataType switch
    {
        CellDataType.Eukaryotic => new CellFactory(CellDataContainer.EukaryoticCellData),
        CellDataType.Prokaryotic => new CellFactory(CellDataContainer.ProkaryoticCellData),
        _ => throw new ArgumentOutOfRangeException(nameof(cellDataType), cellDataType, null)
    };

}
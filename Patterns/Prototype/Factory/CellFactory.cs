using Patterns.Prototype.Data;

namespace Patterns.Prototype.Factory
{
    public class CellFactory : IFactory<Cell.Cell>
    {
        private CellData _cellData;
    
        public CellFactory(CellData cellData)
        {
            _cellData = cellData;
        } 
        
        public Cell.Cell Create()
        {
            return new Cell.Cell(_cellData.NamePrefix, _cellData.CellType, _cellData.Organelles);
        }
    }
}
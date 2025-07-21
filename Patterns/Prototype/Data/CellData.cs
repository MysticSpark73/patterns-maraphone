using Patterns.Prototype.Enums;
using Patterns.Prototype.Organelles;

namespace Patterns.Prototype.Data
{
    public struct CellData
    {
        public string NamePrefix;
        public CellType CellType;
        public Organelle[] Organelles;
    }
}
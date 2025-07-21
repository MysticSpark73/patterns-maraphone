using Patterns.Prototype.Enums;
using Patterns.Prototype.Extensions;
using Patterns.Prototype.NucleicAcids;
using Patterns.Prototype.Organelles;

namespace Patterns.Prototype.Data
{
    public static class CellDataContainer
    {
        private static int _commonDNALength = 25;
    
        public static CellData EukaryoticCellData = new CellData()
        {
            NamePrefix = "Eukaryotic Cell",
            CellType = CellType.Stem,
            Organelles = new Organelle[]
            {
                new Nucleus(new DNA(NucleotidesExtensions.GetRandomNucleotidesChain(_commonDNALength))),
                new Mitochondria(),
                new Mitochondria(),
                new Ribosome()
            }
        };

        public static CellData ProkaryoticCellData = new CellData()
        {
            NamePrefix = "Prokaryotic Cell",
            CellType = CellType.Bacteria,
            Organelles = new Organelle[]
            {
                new Mitochondria(),
                new Ribosome(),
                new Ribosome()
            }
        };
    }
}
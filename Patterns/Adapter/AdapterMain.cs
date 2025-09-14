using Patterns.Adapter.Compounds;
using Patterns.Adapter.Enums;
using Patterns.Common;

namespace Patterns.Adapter
{
    public class AdapterMain : IProgram
    {
        public void Run(object[]? args = null)
        {
            Compound unknown = new Compound();
            unknown.Display();
            RichCompound water = new RichCompound(Chemicals.Water);
            water.Display();
            RichCompound benzene = new RichCompound(Chemicals.Benzene);
            benzene.Display();
            RichCompound ethanol = new RichCompound(Chemicals.Ethanol);
            ethanol.Display();
        }
    }
}
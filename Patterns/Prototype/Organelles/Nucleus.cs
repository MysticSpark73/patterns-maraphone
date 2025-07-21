using Patterns.Prototype.Interfaces;
using Patterns.Prototype.NucleicAcids;

namespace Patterns.Prototype.Organelles
{
    public class Nucleus : Organelle, ICloneable<Nucleus>
    {
        private DNA _dna;

        public Nucleus(DNA dna)
        {
            _dna = dna;
        }

        public override Nucleus Clone()
        {
            return new Nucleus(_dna.Clone());
        }
    }
}
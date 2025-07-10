using Patterns.Prototype.Enums;
using Patterns.Prototype.Interfaces;

namespace Patterns.Prototype.NucleicAcids;

public class DNA : ICloneable<DNA>
{
    //apparently DNA code is usually stored as one strand since you can recreate the second one
    //based on given sequence of nucleotides.
    private Nucleotide[] _nucleotides;

    public Nucleotide[] Read() => _nucleotides;

    public DNA(Nucleotide[] nucleotides)
    {
        _nucleotides = nucleotides;
    }

    private DNA Mutate()
    {
        //todo: implement mutation of random nucleotide
        return this;
    }

    public DNA Clone()
    {
        return new DNA(_nucleotides);
    }
}
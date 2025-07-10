using System;
using System.Linq;
using Patterns.Prototype.Enums;

namespace Patterns.Prototype.Extensions;

public static class NucleotidesExtensions
{
    public static Nucleotide GetRandom(this Nucleotide nucleotide)
    {
        Nucleotide[] nucleotides = Enum.GetValues(typeof(Nucleotide)).Cast<Nucleotide>().ToArray();
        Random random = new Random();
        return nucleotides[random.Next(0, nucleotides.Length)];
    }
}
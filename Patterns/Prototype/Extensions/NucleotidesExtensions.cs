using System;
using System.Linq;
using Patterns.Prototype.Enums;

namespace Patterns.Prototype.Extensions
{
    public static class NucleotidesExtensions
    {
        public static Nucleotide GetRandomNucleotide()
        {
            Nucleotide[] nucleotides = Enum.GetValues(typeof(Nucleotide)).Cast<Nucleotide>().ToArray();
            Random random = new Random();
            return nucleotides[random.Next(0, nucleotides.Length)];
        }

        public static Nucleotide[] GetRandomNucleotidesChain(int length)
        {
            Random random = new Random();
            Nucleotide[] nucleotides = Enum.GetValues(typeof(Nucleotide)).Cast<Nucleotide>().ToArray();
            Nucleotide[] nucleotideChain = new Nucleotide[length];
        
            for (int i = 0; i < length; i++)
            {
                nucleotideChain[i] = nucleotides[random.Next(0, nucleotides.Length)];
            }

            return nucleotideChain;
        }
    }
}
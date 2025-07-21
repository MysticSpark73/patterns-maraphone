using System;
using Patterns.Prototype.Enums;
using Patterns.Prototype.Extensions;
using Patterns.Prototype.Interfaces;

namespace Patterns.Prototype.NucleicAcids
{
    public class DNA : ICloneable<DNA>
    {
        //apparently DNA code is usually stored as one strand since you can recreate the second one
        //based on given sequence of nucleotides.
        private Nucleotide[] _nucleotides;
        private Random _random;

        private readonly float _mutationChance = 5f;

        public Nucleotide[] Read() => _nucleotides;

        public DNA(Nucleotide[] nucleotides)
        {
            _nucleotides = nucleotides;
            _random = new Random();
        }

        private Nucleotide[] TryMutate()
        {
            return IsMutating() ? Mutate() : _nucleotides;
        }

        private bool IsMutating()
        {
            return _random.Next(0, 100) >= _mutationChance;
        }

        private Nucleotide[] Mutate()
        {
            Nucleotide[] newNucleotides = new Nucleotide[_nucleotides.Length];
            int mutationIndex = _random.Next(0, _nucleotides.Length);

            for (int i = 0; i < _nucleotides.Length; i++)
            {
                if (i == mutationIndex)
                {
                    newNucleotides[i] = NucleotidesExtensions.GetRandomNucleotide();
                }
                else
                {
                    newNucleotides[i] = _nucleotides[i];
                }
            }
        
            Console.WriteLine($"Dna mutated\n{_nucleotides} => {newNucleotides}");

            return newNucleotides;
        }

        public DNA Clone()
        {
            return new DNA(TryMutate());
        }
    }
}
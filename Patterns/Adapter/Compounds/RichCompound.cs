using System;
using Patterns.Adapter.DataBank;
using Patterns.Adapter.Enums;

namespace Patterns.Adapter.Compounds
{
    public class RichCompound : Compound
    {
        private readonly Chemicals _chemical;
        private ChemicalDataBank _dataBank;

        public RichCompound(Chemicals chemical)
        {
            _chemical = chemical;
            _dataBank = new ChemicalDataBank();

            _meltingPoint = _dataBank.GetCriticalPoint(_chemical.ToString(), CriticalPoint.MeltingPoint.ToString());
            _boilingPoint = _dataBank.GetCriticalPoint(_chemical.ToString(), CriticalPoint.BoilingPoint.ToString());
            _molecularWeight = _dataBank.GetMolecularWeight(_chemical.ToString());
            _molecularFormula = _dataBank.GetMolecularFormula(_chemical.ToString());
        }

        public override void Display()
        {
            Console.WriteLine($"\nCompound : {_chemical} ---------------");
            Console.WriteLine($"|--> Formula : {_molecularFormula}");
            Console.WriteLine($"|--> Weight : {_molecularWeight}");
            Console.WriteLine($"|--> Boiling Point : {_boilingPoint}");
            Console.WriteLine($"|--> Melting Point : {_meltingPoint}");
        }
    }
}
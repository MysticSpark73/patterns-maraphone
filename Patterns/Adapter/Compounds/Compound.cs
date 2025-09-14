using System;

namespace Patterns.Adapter.Compounds
{
    public class Compound
    {
        protected float _meltingPoint;
        protected float _boilingPoint;
        protected float _molecularWeight;
        protected string _molecularFormula;

        public virtual void Display()
        {
            Console.WriteLine("Unknown Compound");
        }
    }
}
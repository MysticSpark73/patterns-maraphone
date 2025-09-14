namespace Patterns.Adapter.DataBank
{
    public class ChemicalDataBank
    {
        // "Legacy" DataBank API that works wit basic data types 
        public float GetCriticalPoint(string compound, string type)
        {
            switch (type)
            {
                case "M":
                    switch (compound.ToLower())
                    {
                        case "water": return 0.0f;
                        case "benzene": return 5.5f;
                        case "ethanol": return -114.1f;
                        default: return 0;
                    }
                case "B":
                    switch (compound.ToLower())
                    {
                        case "water": return 100.0f;
                        case "benzene": return 80.1f;
                        case "ethanol": return 78.3f;
                        default: return 0f;
                    }
            }

            return 0;
        }

        public string GetMolecularFormula(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return "H20";
                case "benzene": return "C6H6";
                case "ethanol": return "C2H5OH";
                default: return string.Empty;
            }
        }

        public float GetMolecularWeight(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return 18.015f;
                case "benzene": return 78.1134f;
                case "ethanol": return 46.0688f;
                default: return 0f;
            }
        }
    }
}
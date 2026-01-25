using Patterns.Mediator.Airport;
using Patterns.Mediator.Cargos;

namespace Patterns.Mediator.Extensions
{
    public static class LineTypeExtensions
    {
        private static readonly Dictionary<Type, LineType> CargoTypeToLineTypeDictionary = new()
        {
            {typeof(PrivatePlane), LineType.Short},
            {typeof(Plane), LineType.Long},
            {typeof(Helicopter), LineType.Helipad}
        };
        
        public static LineType CargoToLineType(CargoBase cargo)
        {
            if (CargoTypeToLineTypeDictionary.ContainsKey(cargo.GetType()))
            {
                return CargoTypeToLineTypeDictionary[cargo.GetType()];
            }

            return LineType.Undefined;
        }
    }
}
namespace Patterns.Builder.Cars.CarParts
{
    public abstract class CarEngineBase
    {
        protected int _horsePowers;
        protected FuelType _fuelType;

        protected CarEngineBase(FuelType fuelType, int horsePowers)
        {
            _fuelType = fuelType;
            _horsePowers = horsePowers;
        }

        public enum FuelType : byte
        {
            Petrol,
            Diesel,
            Gas,
            Electricity
        }
    }
}
namespace Patterns.Builder.Cars.CarParts
{
    public class CarEngine : CarEngineBase
    {
        protected int _cylindersNumber;
        protected float _volume;
        /// <summary>
        /// Fuel consumption per 100 km
        /// </summary>
        protected float _fuelConsumption;

        public CarEngine(int cylindersNumber, int horsePowers, float volume, float fuelConsumption, FuelType fuelType) : base(fuelType, horsePowers)
        {
            _cylindersNumber = cylindersNumber;
            _horsePowers = horsePowers;
            _volume = volume;
            _fuelConsumption = fuelConsumption;
            _fuelType = fuelType;
        }
    }
}


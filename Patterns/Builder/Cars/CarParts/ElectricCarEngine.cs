namespace Patterns.Builder.Cars.CarParts;

public class ElectricCarEngine : CarEngineBase
{
    private int _batteryCapacity;
    private float _chargeConsumption;
    
    public ElectricCarEngine(int horsePowers, int batteryCapacity, float chargeConsumption, FuelType fuelType = FuelType.Electricity) : base(fuelType, horsePowers)
    {
        _batteryCapacity = batteryCapacity;
        _chargeConsumption = chargeConsumption;
    }
}
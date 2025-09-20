using Patterns.Bridge.Enums;
using Patterns.Bridge.Makes;

namespace Patterns.Bridge.Vehicles
{
    public abstract class Vehicle
    {
        protected Make _make;

        public Vehicle(Make make)
        {
            _make = make;
        }
        
        protected abstract bool IsAllowedToDrive(DrivingLicenseType license);
    }
}
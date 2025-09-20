using Patterns.Bridge.Enums;
using Patterns.Bridge.Makes;

namespace Patterns.Bridge.Vehicles
{
    public class Car : Vehicle
    {
        public Car(Make make) : base(make) { }

        protected override bool IsAllowedToDrive(DrivingLicenseType license)
        {
            switch (license)
            {
                case DrivingLicenseType.B:
                case DrivingLicenseType.BE:
                    return true;
                default: return false;
            }
        }
    }
}
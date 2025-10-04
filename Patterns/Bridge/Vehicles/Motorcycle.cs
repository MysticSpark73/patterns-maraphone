using Patterns.Bridge.Enums;
using Patterns.Bridge.Makes;

namespace Patterns.Bridge.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(Make make) : base(make)
        {
        }

        protected override bool IsAllowedToDrive(DrivingLicenseType license)
        {
            switch (license)
            {
                case DrivingLicenseType.A1:
                case DrivingLicenseType.A2:
                case DrivingLicenseType.A:
                    return true;
                default:
                    return false;
                
            }
        }
    }
}
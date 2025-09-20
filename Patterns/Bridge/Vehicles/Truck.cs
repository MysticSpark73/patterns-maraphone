using Patterns.Bridge.Enums;
using Patterns.Bridge.Makes;

namespace Patterns.Bridge.Vehicles
{
    public class Truck : Vehicle
    {
        protected readonly float _maximumAuthorisedMass;

        public Truck(Make make, float maximumMass) : base(make)
        {
            _maximumAuthorisedMass = maximumMass;
        }

        protected override bool IsAllowedToDrive(DrivingLicenseType license)
        {
            switch (license)
            {
                case DrivingLicenseType.C1:
                    return _maximumAuthorisedMass <= 7500;
                case DrivingLicenseType.C1E:
                    return _maximumAuthorisedMass <= 12000;
                case DrivingLicenseType.C:
                case DrivingLicenseType.CE:
                    return true;
                default: return false;
            }
        }
    }
}
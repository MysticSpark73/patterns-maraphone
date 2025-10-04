using System;
using Patterns.Bridge.Enums;
using Patterns.Bridge.Makes;

namespace Patterns.Bridge.Vehicles
{
    public abstract class Vehicle
    {
        public Make Make => _make;
        
        protected Make _make;

        public Vehicle(Make make)
        {
            _make = make;
        }

        public void Start() => _make.Start();

        public virtual void CheckDrivingLicense(DrivingLicenseType licenseType)
        {
            Console.WriteLine("You are {0} to drive this vehicle of type: {1} and make {2} ",
                IsAllowedToDrive(licenseType) ? "allowed" : "not allowed", GetType(), _make.GetType());
        }
        
        protected abstract bool IsAllowedToDrive(DrivingLicenseType license);
    }
}
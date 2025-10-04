using Patterns.Bridge.Enums;
using Patterns.Bridge.Makes;
using Patterns.Bridge.Vehicles;
using Patterns.Common;

namespace Patterns.Bridge
{
    public class BridgeMain : IProgram
    {
        private Truck _truck;
        private Car _carHonda;
        private Car _carTesla;
        private Motorcycle _motorcycle;
        
        public void Run(object[]? args = null)
        {
            CreateVehicles();
            CheckVehicles();
        }

        private void CreateVehicles()
        {
            _truck = new Truck( new Ford(), 8000);
            _carHonda = new Car(new Honda());
            _carTesla = new Car(new Tesla());
            _motorcycle = new Motorcycle(new Honda());
        }

        private void CheckVehicles()
        {
            _motorcycle.Start();
            _motorcycle.CheckDrivingLicense(DrivingLicenseType.A1);
            
            _truck.Start();
            _truck.CheckDrivingLicense(DrivingLicenseType.C1E);
            
            _carHonda.Start();
            _carHonda.CheckDrivingLicense(DrivingLicenseType.B);
            Honda honda = _carHonda.Make as Honda;
            if (honda != null)
            {
                honda.EnableRecuperation(true);
                honda.EnableCruiseControl(true);
                honda.EnableSeatHeating(true);
                honda.EnableTractionControl(true);
            }
            
            _carTesla.Start();
            _carTesla.CheckDrivingLicense(DrivingLicenseType.B1);
            Tesla tesla = _carTesla.Make as Tesla;
            if (tesla != null)
            {
                tesla.EnableTheAutopilotMode(true);
                tesla.Charge();
            }
        }
    }
}
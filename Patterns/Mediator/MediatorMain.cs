using Patterns.Common;
using Patterns.Mediator.Airport;
using Patterns.Mediator.Cargos;

namespace Patterns.Mediator
{
    public class MediatorMain : IProgram
    {
        private Airport.Airport _airport;
        private FlightControlMediator _flightControlMediator;
        private List<CargoBase> _cargo;

        public void Run(object[]? args = null)
        {
            CreateAirport();
            CreateCargos();
        }

        private void CreateAirport()
        {
            _airport = new Airport.Airport();
            _flightControlMediator = new FlightControlMediator(_airport);
        }

        private void CreateCargos()
        {
            _cargo = new List<CargoBase>
            {
                new Plane("Boeing 737 1", _flightControlMediator),
                new Plane("Airbus A320 1", _flightControlMediator),
                new Plane("Boeing 737 2", _flightControlMediator),
                new PrivatePlane("Cirrus SR22T", _flightControlMediator),
                new PrivatePlane("Cessna 182", _flightControlMediator),
                new Helicopter("Bell 429", _flightControlMediator),
                new Helicopter("Airbus H125", _flightControlMediator),
            };
        }
    }
}
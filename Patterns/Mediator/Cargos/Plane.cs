using Patterns.Mediator.Airport;

namespace Patterns.Mediator.Cargos
{
    public class Plane : CargoBase
    {
        public Plane(string name, FlightControlMediator flightControlMediator) : base(name, flightControlMediator)
        {
        }
    }
}
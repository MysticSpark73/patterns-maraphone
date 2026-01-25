using Patterns.Mediator.Airport;

namespace Patterns.Mediator.Cargos
{
    public class PrivatePlane : CargoBase
    {
        public PrivatePlane(string name, FlightControlMediator flightControlMediator) : base(name, flightControlMediator)
        {
        }
    }
}
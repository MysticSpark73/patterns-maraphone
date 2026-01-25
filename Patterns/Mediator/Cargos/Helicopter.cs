using Patterns.Mediator.Airport;

namespace Patterns.Mediator.Cargos
{
    public class Helicopter : CargoBase
    {
        public Helicopter(string name, FlightControlMediator flightControlMediator) : base(name, flightControlMediator)
        {
        }
    }
}
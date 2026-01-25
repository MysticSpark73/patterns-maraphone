using Patterns.Mediator.Airport;

namespace Patterns.Mediator.Cargos
{
    public abstract class CargoBase : ICargo
    {
        public string Name { get; private set; }
        private readonly FlightControlMediator _flightControlMediator;
        private LandingRequestResponse? _lastReceivedResponse;

        protected CargoBase(string name, FlightControlMediator flightControlMediator)
        {
            Name = name;
            _flightControlMediator = flightControlMediator;

            _lastReceivedResponse = RequestLanding();

            if (_lastReceivedResponse.Value.Status)
            {
                Land();
            }
            else
            {
                Delay();
            }
        }

        public void Land()
        {
            if (_lastReceivedResponse.HasValue && _lastReceivedResponse.Value.TakeoffLine.HasValue)
            {
                _flightControlMediator.NotifyLanding(this, _lastReceivedResponse.Value.TakeoffLine.Value);
            }
            else
            {
                Console.Out.WriteLine("Unable to land {0} because {1}!\nDelaying landing as a backup.", Name,
                    _lastReceivedResponse.HasValue
                        ? _lastReceivedResponse.Value.TakeoffLine.HasValue ? "IDK" : "the takeoff line is null"
                        : "response from the airport is missing");
                Delay();
            }
        }
        
        public void Delay() => _flightControlMediator.NotifyDelay(this);
        
        public LandingRequestResponse RequestLanding() => _flightControlMediator.RequestLanding(this);
    }
}
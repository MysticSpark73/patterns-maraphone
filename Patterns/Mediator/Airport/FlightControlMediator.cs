using Patterns.Mediator.Cargos;
using Patterns.Mediator.Extensions;

namespace Patterns.Mediator.Airport
{
    public class FlightControlMediator
    {
        private Airport _airport;
        private Queue<CargoBase> _landingQueue = new ();
        public FlightControlMediator(Airport airport)
        {
            _airport = airport;
        }

        public LandingRequestResponse RequestLanding(CargoBase cargo)
        {
            Console.Out.WriteLine("\nCargo {0} requests landing", cargo.Name);
            
            LandingRequestResponse response = new LandingRequestResponse();

            LineType lineType = LineTypeExtensions.CargoToLineType(cargo);
            
            if (lineType == LineType.Undefined) return response;
            
            var takeoffLine = _airport.GetAvailableLine(lineType);

            Console.Out.WriteLine(takeoffLine == null
                ? "There is no available line for landing for this cargo!"
                : $"Found available line: {takeoffLine.Value.Name}");
            
            response.Status = takeoffLine != null;
            response.TakeoffLine = takeoffLine;
            return response;
        }

        public void NotifyLanding(CargoBase cargo, TakeoffLine line)
        {
            Console.Out.WriteLine("Cargo {0} is landing onto {1}", cargo.Name, line.Name);
            _airport.SetLineState(line, false);
        }

        public void NotifyDelay(CargoBase cargo)
        {
            Console.Out.WriteLine("Cargo {0} landing has been delayed!", cargo.Name);
            _landingQueue.Enqueue(cargo);
        }
    }
}
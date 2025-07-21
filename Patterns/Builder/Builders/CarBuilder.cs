using System.Drawing;
using Patterns.Builder.Cars;
using Patterns.Builder.Cars.CarParts;

namespace Patterns.Builder.Builders
{
    public class CarBuilder : ICarBuilder
    {
        protected CarBlueprint _carBlueprint;

        public CarBuilder()
        {
            Reset();
        }

        public Car Build()
        {
            return new Car(_carBlueprint);
        }

        public IBuilder<Car> Reset()
        {
            _carBlueprint = new CarBlueprint();
            return this;
        }

        public ICarBuilder AddEngine(CarEngineBase engine)
        {
            _carBlueprint.Engine = engine;
            return this;
        }

        public ICarBuilder SetColor(Color color)
        {
            _carBlueprint.Color = color;
            return this;
        }

        public ICarBuilder SetTransmissionType(TransmissionType transmissionType)
        {
            _carBlueprint.TransmissionType = transmissionType;
            return this;
        }

        public ICarBuilder SetSeatsNumber(int seatsNumber)
        {
            _carBlueprint.SeatsNumber = seatsNumber;
            return this;
        }

        public ICarBuilder SetTripComputer(bool tripComputer)
        {
            _carBlueprint.TripComputer = tripComputer;
            return this;
        }

        public ICarBuilder SetTrunk(bool hasTrunk)
        {
            _carBlueprint.HasTrunk = hasTrunk;
            return this;
        }

        public ICarBuilder SetTurbo(bool hasTurbo)
        {
            _carBlueprint.Turbo = hasTurbo;
            return this;
        }

        public ICarBuilder SetWinch(bool hasWinch)
        {
            _carBlueprint.Winch = hasWinch;
            return this;
        }
    }
}
using System.Drawing;
using Patterns.Builder.Builders;
using Patterns.Builder.Cars;
using Patterns.Builder.Cars.CarParts;

namespace Patterns.Builder.Directors
{
    public class SportsCarsDirector<T, TBuilder> : CarDirector<T, TBuilder> where TBuilder : ICarBuilder
    {
        public override Car BuildCar(CarEngineBase engine)
        {
            _builder.Reset();
            _builder.AddEngine(engine);
            _builder.SetColor(Color.Red);
            _builder.SetTransmissionType(TransmissionType.AWD);
            _builder.SetSeatsNumber(2);
            _builder.SetTripComputer(false);
            _builder.SetTrunk(true);
            _builder.SetTurbo(true);
            _builder.SetWinch(false);
            return _builder.Build();
        }
    }
}
using System.Drawing;
using Patterns.Builder.Builders;
using Patterns.Builder.Cars;
using Patterns.Builder.Cars.CarParts;

namespace Patterns.Builder.Directors;

public class CarDirector<T, TBuilder> : IDirector<T> where TBuilder : ICarBuilder
{
    protected TBuilder _builder;

    public void SetBuilder(IBuilder<T> builder) => _builder = (TBuilder) builder;

    public virtual Car BuildCar(CarEngineBase engine)
    {
        _builder.Reset();
        _builder.AddEngine(engine);
        _builder.SetColor(Color.White);
        _builder.SetTransmissionType(TransmissionType.TwoWheelDrive);
        _builder.SetSeatsNumber(5);
        _builder.SetTripComputer(true);
        _builder.SetTrunk(true);
        _builder.SetTurbo(false);
        _builder.SetWinch(false);
        return _builder.Build();
    }
}
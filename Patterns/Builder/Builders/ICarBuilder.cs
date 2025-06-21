using System.Drawing;
using Patterns.Builder.Cars;
using Patterns.Builder.Cars.CarParts;

namespace Patterns.Builder.Builders;

public interface ICarBuilder : IBuilder<Car>
{
    abstract ICarBuilder AddEngine(CarEngineBase carEngineBase);
    abstract ICarBuilder SetColor(Color color);
    abstract ICarBuilder SetTransmissionType(TransmissionType transmissionType);
    abstract ICarBuilder SetSeatsNumber(int seatsNumber);
    abstract ICarBuilder SetTripComputer(bool tripComputer);
    abstract ICarBuilder SetTrunk(bool hasTrunk);
    abstract ICarBuilder SetTurbo(bool hasTurbo);
    abstract ICarBuilder SetWinch(bool hasWinch);
}
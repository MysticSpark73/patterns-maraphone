using System.Drawing;
using Patterns.Builder.Cars.CarParts;

namespace Patterns.Builder.Cars;

public class CarBlueprint
{
    public CarEngineBase Engine {get; set;}
    public Color Color {get; set;}
    public TransmissionType TransmissionType {get; set;}
    public int SeatsNumber {get; set;}
    public bool TripComputer {get; set;}
    public bool HasTrunk {get; set;}
    public bool Turbo {get; set;}
    public bool Winch {get; set;}
}
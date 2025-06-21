using Patterns.AbstractFactory.Furniture;
using Patterns.AbstractFactory.Furniture.Victorian;

namespace Patterns.AbstractFactory.Factories;

public class VictorianFactory : IAbstractFurnitureFactory
{
    public IChair CreateChair()
    {
        return new VictorianChair();
    }

    public ICouch CreateCouch()
    {
        return new VictorianCouch();
    }

    public ITable CreateTable()
    {
        return new VictorianTable();
    }
}
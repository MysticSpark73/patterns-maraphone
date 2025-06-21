using Patterns.AbstractFactory.Furniture;

namespace Patterns.AbstractFactory.Factories;

public interface IAbstractFurnitureFactory
{
    public IChair CreateChair();

    public ICouch CreateCouch();

    public ITable CreateTable();
}
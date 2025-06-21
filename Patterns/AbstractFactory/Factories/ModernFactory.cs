using Patterns.AbstractFactory.Furniture;
using Patterns.AbstractFactory.Furniture.Modern;

namespace Patterns.AbstractFactory.Factories;

public class ModernFactory : IAbstractFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ModernChair();
    }

    public ICouch CreateCouch()
    {
        return new ModernCouch();
    }

    public ITable CreateTable()
    {
        return new ModernTable();
    }
}
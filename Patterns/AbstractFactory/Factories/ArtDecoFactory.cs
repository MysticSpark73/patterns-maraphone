using Patterns.AbstractFactory.Furniture;
using Patterns.AbstractFactory.Furniture.ArtDeco;

namespace Patterns.AbstractFactory.Factories
{
    public class ArtDecoFactory : IAbstractFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new ArtDecoChair();
        }

        public ICouch CreateCouch()
        {
            return new ArtDecoCouch();
        }

        public ITable CreateTable()
        {
            return new ArtDecoTable();
        }
    }
}
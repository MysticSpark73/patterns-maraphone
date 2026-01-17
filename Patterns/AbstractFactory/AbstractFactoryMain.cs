using Patterns.AbstractFactory.Factories;
using Patterns.AbstractFactory.Furniture;
using Patterns.Common;

namespace Patterns.AbstractFactory
{
    public class AbstractFactoryMain : IProgram
    {
        private IAbstractFurnitureFactory _factory;
        private FurnitureType _furnitureType;
        private FurnitureSet _furnitureSet;

        private readonly string[] testObjects =
        {
            "Apple",
            "Laptop",
            "Phone",
            "Cup of coffee"
        };
    
        public void Run(object[]? args = null)
        {
            TryReadArgs(args, out _furnitureType);
            _factory = BuildTheFactory(_furnitureType);
            _furnitureSet = CreateFurnitureSet(_factory);
            _furnitureSet.Inspect(testObjects);
        }

        private static bool TryReadArgs(object[]? args, out FurnitureType furnitureType)
        {
            furnitureType = FurnitureType.ArtDeco;
            if(args == null || args.Length == 0) return false;
            try
            {
                furnitureType = (FurnitureType) args[0];
                return true;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private IAbstractFurnitureFactory BuildTheFactory(FurnitureType furnitureType)
        {
            switch (furnitureType)
            {
                case FurnitureType.ArtDeco:
                    return new ArtDecoFactory();
                case FurnitureType.Modern:
                    return new ModernFactory();
                case FurnitureType.Victorian:
                    return new VictorianFactory();
                default:
                    throw new ArgumentOutOfRangeException(nameof(furnitureType), furnitureType, null);
            }
        }

        private FurnitureSet CreateFurnitureSet(IAbstractFurnitureFactory factory)
        {
            return new FurnitureSet(factory.CreateChair(), factory.CreateCouch(), factory.CreateTable());
        }

        public enum FurnitureType : byte
        {
            ArtDeco = 0,
            Modern = 1,
            Victorian = 2
        }

        private class FurnitureSet
        {
            private IChair _chair;
            private ICouch _couch;
            private ITable _table;

            public FurnitureSet(IChair chair, ICouch couch, ITable table)
            {
                _chair = chair;
                _couch = couch;
                _table = table;
            }

            public void Inspect(string[]? objects)
            {
                _chair.SitOn();
                _couch.SitOn();
                _couch.LayOn();
                if (objects != null) _table.PutOn(objects);
            }
        }
    }
}
using Patterns.AbstractFactory;
using Patterns.Builder;
using Patterns.Factory;
using Patterns.Prototype;

namespace Patterns;

internal abstract class Program
{
    static void Main(string[] args)
    {
        // RunAbstractFactory(new object[] { AbstractFactoryMain.FurnitureType.Modern });
        // RunBuilder();
    }

    private static void RunFactory()
    {
        FactoryMain factoryMain = new FactoryMain();
        factoryMain.Run();
    }

    private static void RunAbstractFactory(object[]? args = null)
    {
        AbstractFactoryMain abstractFactoryMain = new AbstractFactoryMain();
        abstractFactoryMain.Run(args);
    }

    private static void RunBuilder()
    {
        BuilderMain builder = new BuilderMain();
        builder.Run();
    }

    private static void RunPrototype()
    {
        PrototypeMain prototype = new PrototypeMain();
        prototype.Run(new []{"Eukaryotic"});
    }
}
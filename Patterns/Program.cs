using Patterns.AbstractFactory;
using Patterns.Adapter;
using Patterns.Bridge;
using Patterns.Builder;
using Patterns.Composite;
using Patterns.Factory;
using Patterns.Prototype;
using Patterns.Singleton;

namespace Patterns
{
    internal abstract class Program
    {
        static void Main(string[] args)
        {
            // RunAbstractFactory(new object[] { AbstractFactoryMain.FurnitureType.Modern });
            // RunBuilder();
            // RunPrototype();
            // RunSingleton();
            // RunAdapter();
            // RunBridge();
            RunComposite();
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

        private static void RunSingleton()
        {
            SingletonMain singleton = new SingletonMain();
            singleton.Run();
        }

        private static void RunAdapter()
        {
            AdapterMain adapter = new AdapterMain();
            adapter.Run();
        }
        
        //Structural

        private static void RunBridge()
        {
            BridgeMain bridge = new BridgeMain();
            bridge.Run();
        }

        private static void RunComposite()
        {
            CompositeMain composite = new CompositeMain();
            composite.Run();
        }
    }
}
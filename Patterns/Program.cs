using Patterns.AbstractFactory;
using Patterns.Adapter;
using Patterns.Bridge;
using Patterns.Builder;
using Patterns.Composite;
using Patterns.Decorator;
using Patterns.Facade;
using Patterns.Factory;
using Patterns.Flyweight;
using Patterns.Prototype;
using Patterns.Proxy;
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
            // RunComposite();
            // RunDecorator();
            // RunFacade();
            // RunFlyweight();
            RunProxy();
        }

        #region Creational

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
            prototype.Run(new[] {"Eukaryotic"});
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

        #endregion

        #region Structural

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

        private static void RunDecorator()
        {
            DecoratorMain decorator = new DecoratorMain();
            decorator.Run();
        }

        private static void RunFacade()
        {
            FacadeMain facade = new FacadeMain();
            facade.Run();
        }

        private static void RunFlyweight()
        {
            FlyweightMain flyweight = new FlyweightMain();
            flyweight.Run();
        }

        private static void RunProxy()
        {
            ProxyMain proxy = new ProxyMain();
            proxy.Run();
        }

        #endregion
    }
}
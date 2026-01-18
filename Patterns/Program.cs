using Patterns.AbstractFactory;
using Patterns.Adapter;
using Patterns.Bridge;
using Patterns.Builder;
using Patterns.ChainOfResponsibility;
using Patterns.Command;
using Patterns.Composite;
using Patterns.Decorator;
using Patterns.Facade;
using Patterns.Factory;
using Patterns.Flyweight;
using Patterns.Iterator;
using Patterns.Prototype;
using Patterns.Proxy;
using Patterns.Singleton;

namespace Patterns
{
    internal abstract class Program
    {
        static void Main(string[] args)
        {
            // Creational.RunAbstractFactory(new object[] { AbstractFactoryMain.FurnitureType.Modern });
            // Creational.RunBuilder();
            // Creational.RunPrototype();
            // Creational.RunSingleton();
            // Creational.RunAdapter();
            // Structural.RunBridge();
            // Structural.RunComposite();
            // Structural.RunDecorator();
            // Structural.RunFacade();
            // Structural.RunFlyweight();
            // Structural.RunProxy();
            // Behavioral.RunChainOfResponsibility();
            // Behavioral.RunCommand();
            Behavioral.RunIterator();
        }

        private static class Creational
        {
            public static void RunFactory()
            {
                FactoryMain factoryMain = new FactoryMain();
                factoryMain.Run();
            }

            public static void RunAbstractFactory(object[]? args = null)
            {
                AbstractFactoryMain abstractFactoryMain = new AbstractFactoryMain();
                abstractFactoryMain.Run(args);
            }

            public static void RunBuilder()
            {
                BuilderMain builder = new BuilderMain();
                builder.Run();
            }

            public static void RunPrototype()
            {
                PrototypeMain prototype = new PrototypeMain();
                prototype.Run(new[] {"Eukaryotic"});
            }

            public static void RunSingleton()
            {
                SingletonMain singleton = new SingletonMain();
                singleton.Run();
            }

            public static void RunAdapter()
            {
                AdapterMain adapter = new AdapterMain();
                adapter.Run();
            }
        }

        private static class Structural
        {
            public static void RunBridge()
            {
                BridgeMain bridge = new BridgeMain();
                bridge.Run();
            }

            public static void RunComposite()
            {
                CompositeMain composite = new CompositeMain();
                composite.Run();
            }

            public static void RunDecorator()
            {
                DecoratorMain decorator = new DecoratorMain();
                decorator.Run();
            }

            public static void RunFacade()
            {
                FacadeMain facade = new FacadeMain();
                facade.Run();
            }

            public static void RunFlyweight()
            {
                FlyweightMain flyweight = new FlyweightMain();
                flyweight.Run();
            }

            public static void RunProxy()
            {
                ProxyMain proxy = new ProxyMain();
                proxy.Run();
            }
        }
        
        private static class Behavioral
        {
            public static void RunChainOfResponsibility()
            {
                ChainOfResponsibilityMain chainOfResponsibility = new ChainOfResponsibilityMain();
                chainOfResponsibility.Run();
            }

            public static void RunCommand()
            {
                CommandMain commandMain = new CommandMain();
                commandMain.Run();
            }

            public static void RunIterator()
            {
                IteratorMain iteratorMain = new IteratorMain();
                iteratorMain.Run();
            }
        }
    }
}
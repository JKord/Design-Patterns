using System;

#region Structural
using Patterns.Structural.Adapter;
using Patterns.Structural.Bridge;
using Patterns.Structural.Decorator;
using Patterns.Structural.Facade;
using Patterns.Structural.Flyweight;
using Patterns.Structural.Proxy;
#endregion

namespace Patterns.Structural
{
    class Run
    {
        public Run()
        {
            Console.WriteLine("Structural Patterns:");
        }

        //Компонувальник - Composite
        public Run Composite() 
        {
            Console.WriteLine("Composite:");

            // Create a tree structure
            Patterns.Structural.Composite.Component root = new Patterns.Structural.Composite.Composite("root");

            root.Add(new Patterns.Structural.Composite.Leaf("Leaf A"));
            root.Add(new Patterns.Structural.Composite.Leaf("Leaf B"));

            Patterns.Structural.Composite.Component comp = new Patterns.Structural.Composite.Composite("Composite X");

            comp.Add(new Patterns.Structural.Composite.Leaf("Leaf XA"));
            comp.Add(new Patterns.Structural.Composite.Leaf("Leaf XB"));
            root.Add(comp);
            root.Add(new Patterns.Structural.Composite.Leaf("Leaf C"));

            // Add and remove a leaf
            Patterns.Structural.Composite.Leaf leaf = new Patterns.Structural.Composite.Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            root.Display(1);

            return this;
        }
        
        //Адаптер - Adapter
        public Run Adapter() 
        {
            Console.WriteLine("\nAdapter:");

            // Create adapter and place a request
            Target target = new Patterns.Structural.Adapter.Adapter();
            target.Request();

            return this;
        }

        //Міст - Bridge
        public Run Bridge() 
        {
            Console.WriteLine("\nBridge:");

            Abstraction ab = new RefinedAbstraction();

            // Set implementation and call
            ab.Implementor = new ConcreteImplementorA();
            ab.Operation();

            // Change implementation and call
            ab.Implementor = new ConcreteImplementorB();
            ab.Operation();

            return this;
        }

        //Декоратор або Wrapper / Обгортка (Decorator)
        public Run Decorator() 
        {
            Console.WriteLine("\nDecorator:");

            // Create ConcreteComponent and two Decorators
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            return this;
        }

        //Фвсад - Facade
        public Run Facade()
        {
            Console.WriteLine("\nFacade:");

            Patterns.Structural.Facade.Facade.Operation1();
            Patterns.Structural.Facade.Facade.Operation2();

            return this;
        }

        //Пристосуванець - Flyweight
        public Run Flyweight() 
        {
            Console.WriteLine("\nFlyweight:");

            // Arbitrary extrinsic state
            int extrinsicstate = 22;

            FlyweightFactory factory = new FlyweightFactory();

            // Work with different flyweight instances
            Patterns.Structural.Flyweight.Flyweight fx = factory.GetFlyweight("X");
            fx.Operation(--extrinsicstate);

            Patterns.Structural.Flyweight.Flyweight fy = factory.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);

            Patterns.Structural.Flyweight.Flyweight fz = factory.GetFlyweight("Z");
            fz.Operation(--extrinsicstate);

            UnsharedConcreteFlyweight fu = new
              UnsharedConcreteFlyweight();

            fu.Operation(--extrinsicstate);

            return this;
        }

        //Замісник - Proxy
        public Run Proxy() 
        {
            Console.WriteLine("\nProxy:");

            // Create math proxy
            MathProxy p = new MathProxy();

            // Do the math
            Console.WriteLine("4 + 2 = " + p.Add(4, 2));
            Console.WriteLine("4 - 2 = " + p.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + p.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + p.Div(4, 2));

            return this;
        }
    }
}

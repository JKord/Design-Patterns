namespace Patterns.Creational.FactoryMethod
{
    // Product
    abstract class Product
    {
    }

    // "ConcreteProductA"
    class ConcreteProductA : Product
    {
    }

    // "ConcreteProductB"
    class ConcreteProductB : Product
    {
    }

    // "Creator"
    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    // "ConcreteCreatorA"
    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    // "ConcreteCreatorB"
    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}

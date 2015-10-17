namespace Patterns
{
    public static class RunPatterns
    {
        public static void Structural()
        {
            new Patterns.Structural.Run()
                 .Composite()
                 .Adapter()
                 .Bridge()
                 .Decorator()
                 .Facade()
                 .Flyweight()
                 .Proxy()
             ;
        }

        public static void Creational()
        {
            new Patterns.Creational.Run()
                 .AbstractFactory()
                 .Builder()
                 .FactoryMethod()
                 .LazyInitialization()
                 .ObjectPool()
                 .Prototype()
                 .Singleton()
            ;
        }

        public static void Behavioral()
        {
            new Patterns.Behavioral.Run()
                  .ChainoOfResponsibility()
                  .Iterator()
                  .Mediator()
                  .Observer()
                  .Strategy()
                  .NullObject()
                  .TemplateMethod()
                  .Visitor()
            ;
        }
    }
}

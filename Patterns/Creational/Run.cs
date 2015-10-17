using System;
using System.Threading;

#region Creational
using Patterns.Creational.AbstractFactory;
using Patterns.Creational.FactoryMethod;
using Patterns.Creational.LazyInitialization;
using Patterns.Creational.ObjectPool;
using Patterns.Creational.Prototype;
#endregion

namespace Patterns.Creational
{
    class Run
    {
        public Run()
        {
            Console.WriteLine("Creational Patterns:");
        }

        //Aбстрактна фабрика - Abstract Factory
        public Run AbstractFactory()
        {
            Console.WriteLine("Abstract Factory:");

            // Abstract factory #1
            Patterns.Creational.AbstractFactory.AbstractFactory factory1 = new ConcreteFactory1();
            Client c1 = new Client(factory1);
            c1.Run();

            // Abstract factory #2
            Patterns.Creational.AbstractFactory.AbstractFactory factory2 = new ConcreteFactory2();
            Client c2 = new Client(factory2);
            c2.Run();

            return this;
        }

        //Будівельник - Builder
        public Run Builder()
        {
            Console.WriteLine("\nBuilder:");

            // Create director and builders
            Patterns.Creational.Builder.Director director = new Patterns.Creational.Builder.Director();

            Patterns.Creational.Builder.Builder b1 = new Patterns.Creational.Builder.ConcreteBuilder1();
            Patterns.Creational.Builder.Builder b2 = new Patterns.Creational.Builder.ConcreteBuilder2();

            // Construct two products
            director.Construct(b1);
            Patterns.Creational.Builder.Product p1 = b1.GetResult();
            p1.Show();

            director.Construct(b2);
            Patterns.Creational.Builder.Product p2 = b2.GetResult();
            p2.Show();

            return this;
        }

        //Фабричний метод - Factory Method
        public Run FactoryMethod()
        {
            Console.WriteLine("\nFactory Method:");

            // an array of creators
            Patterns.Creational.FactoryMethod.Creator[] creators = { new Patterns.Creational.FactoryMethod.ConcreteCreatorA(), new Patterns.Creational.FactoryMethod.ConcreteCreatorB() };

            // iterate over creators and create products
            foreach (Patterns.Creational.FactoryMethod.Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}", product.GetType());
            }

            return this;
        }

        //Лінива ініціалізація - Lazy Initialization
        public Run LazyInitialization()
        {
            Console.WriteLine("\nLazy Initialization:");

            System.Console.WriteLine("Первое обращение к экземпляру BigObject...");

            //создание объекта происходит только при этом обращении к объекту
            System.Console.WriteLine(BigObject.Instance);

            System.Console.WriteLine("Второе обращение к экземпляру BigObject...");
            System.Console.WriteLine(BigObject.Instance);

            return this;
        }

        #region Object Pool

        private void RunObjectPool(Object obj)
        {
            Console.WriteLine("\t" + System.Reflection.MethodInfo.GetCurrentMethod().Name);
            var reusablePool = (ReusablePool)obj;
            Console.WriteLine("\tstart wait");
            var thisObject1 = reusablePool.WaitForObject();
            ViewObject(thisObject1);
            Console.WriteLine("\tend wait");
            reusablePool.Release(thisObject1);
        }
        private void ViewObject(Reusable thisObject)
        {
            foreach (var obj in thisObject.Objs)
            {
                Console.Write(obj.ToString() + @" ");
            }
            Console.WriteLine();
        }

        //Об'єктний пул - Object Pool
        public Run ObjectPool()
        {
            Console.WriteLine("\nObject Pool:");

            Console.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name);
            var reusablePool = new ReusablePool();

            var thrd1 = new Thread(RunObjectPool);
            var thrd2 = new Thread(RunObjectPool);
            var thisObject1 = reusablePool.GetObject();
            var thisObject2 = reusablePool.GetObject();
            thrd1.Start(reusablePool);
            thrd2.Start(reusablePool);
            ViewObject(thisObject1);
            ViewObject(thisObject2);
            Thread.Sleep(2000);
            reusablePool.Release(thisObject1);
            Thread.Sleep(2000);
            reusablePool.Release(thisObject2);

            return this;
        }
        
        #endregion

        //Прототип - Prototype
        public Run Prototype()
        {
            Console.WriteLine("\nPrototype:");

            // Create two instances and clone each
            Patterns.Creational.Prototype.Prototype p1 = new ConcretePrototype1("I");
            Patterns.Creational.Prototype.Prototype c1 = p1.Clone();
            Console.WriteLine("Cloned: {0}", c1.Id);

            Patterns.Creational.Prototype.Prototype p2 = new ConcretePrototype2("II");
            Patterns.Creational.Prototype.Prototype c2 = p2.Clone();
            Console.WriteLine("Cloned: {0}", c2.Id);

            return this;
        }

        //AОдинак - Singleton
        public Run Singleton()
        {
            Console.WriteLine("\nSingleton:");
            Object obj = Patterns.Creational.Singleton.Singleton.MyInstance;

            return this;
        }
    }
}

using System;

#region Behavioral
using Patterns.Behavioral.ChainoOfResponsibility;
using Patterns.Behavioral.Mediator;
using Patterns.Behavioral.Memento;
using Patterns.Behavioral.Observer;
using Patterns.Behavioral.Strategy;
using Patterns.Behavioral.NullObject;
using Patterns.Behavioral.TemplateMethod;
using Patterns.Behavioral.Visitor;
#endregion

namespace Patterns.Behavioral
{
    class Run
    {
        public Run()
        {
            Console.WriteLine("\nBehavioral Patterns:");
        }

        //Aбстрактна фабрика - Abstract Factory
        public Run AbstractFactory()
        {
            Console.WriteLine("Abstract Factory:");
            return this;
        }

        //Ланцюжок відповідальностей - Chaino Of Responsibility
        public Run ChainoOfResponsibility()
        {
            Console.WriteLine("Chaino Of Responsibility:");

            Chain chain = new StringHandler();
            chain += new IntegerBypassHandler();
            chain += new IntegerHandler();
            chain += new IntegerHandler(); // ніколи не дойде сюди
            chain += new NullHandler();

            chain.Message("1st string value");
            chain.Message(100);
            chain.Message("2nd string value");
            chain.Message(4.7f); // не обробляється
            chain.Message(null);

            return this;
        }

        //Ітератор - Iterator
        public Run Iterator()
        {
            Console.WriteLine("\nIterator:");

            string[] strings = new string[] { "one", "two", "three" };
            foreach (string str in strings)
                Console.WriteLine(str);
           
            return this;
        }

        //Посередник - Mediator
        public Run Mediator()
        {
            Console.WriteLine("\nMediator:");

            ConcreteMediator m = new ConcreteMediator();

            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);

            m.Colleague1 = c1;
            m.Colleague2 = c2;

            c1.Send("How are you?");
            c2.Send("Fine, thanks");

            return this;
        }

        //Зберігач - Token, Memento
        public Run Memento()
        {
            Console.WriteLine("\nMemento:");

            Originator o = new Originator();
            o.State = "On";

            // Store internal state
            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();

            // Continue changing originator
            o.State = "Off";

            // Restore saved state
            o.SetMemento(c.Memento);

            return this;
        }

        //Спостерігач - Observer, Dependents, Publish-Subscribe, Listener
        public Run Observer()
        {
            Console.WriteLine("\nObserver:");

            Subject subject = new Subject();
            Patterns.Behavioral.Observer.Observer Observer = new Patterns.Behavioral.Observer.Observer(subject, "Center", "\t\t");
            Patterns.Behavioral.Observer.Observer observer2 = new Patterns.Behavioral.Observer.Observer(subject, "Right", "\t\t\t\t");
            subject.Go();

            return this;
        }

        //Стратегія - Strategy
        public Run Strategy()
        {
            Console.WriteLine("\nStrategy:");

            // Створюємо контекст і ініціалізували його першої стратегією.
            Context context = new Context(new ConcreteStrategy1());
            // Виконуємо операцію контексту, яка використовує першу стратегію.
            context.ExecuteOperation();
            // Замінюємо в контексті першу стратегію другою.
            context.SetStrategy(new ConcreteStrategy2());
            // Виконуємо операцію контексту, яка тепер використовує другу стратегію.
            context.ExecuteOperation();

            return this;
        }

        //Null Object
        public Run NullObject()
        {
            Console.WriteLine("\nNull Object:");

            Animal dog = new Dog();
            dog.MakeSound(); //

            Animal unknown = new NullAnimal();  //<< замінює: Animal unknown = null;
            unknown.MakeSound(); // нічого не відбувається

            return this;
        }

        #region Template Method

        TemplateMethodImp templateMethodImpObject;

        void ChangedBusinessLogic()
        {
            templateMethodImpObject.DisplayOne();
            templateMethodImpObject.DisplayThree();
        }

        //Шаблонний метод - TemplateMethod
        public Run TemplateMethod()
        {
            Console.WriteLine("\nTemplate Method:");

            templateMethodImpObject = new TemplateMethodImp();

            templateMethodImpObject.Execute(templateMethodImpObject.DisplayTwo);
            templateMethodImpObject.Execute(ChangedBusinessLogic);

            return this;
        }

        #endregion

        //Відвідувач - Visitor
        public Run Visitor()
        {
            Console.WriteLine("\nVisitor:");

            // Setup structure 
            ObjectStructure o = new ObjectStructure();
            o.Attach(new ConcreteElementA());
            o.Attach(new ConcreteElementB());

            // Create visitor objects 
            ConcreteVisitor1 v1 = new ConcreteVisitor1();
            ConcreteVisitor2 v2 = new ConcreteVisitor2();

            // Structure accepting visitors 
            o.Accept(v1);
            o.Accept(v2);

            return this;
        }
    }
}

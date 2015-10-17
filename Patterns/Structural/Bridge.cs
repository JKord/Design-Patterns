using System;

namespace Patterns.Structural.Bridge
{
    /// <summary>
    /// Abstraction - абстракция
    /// </summary>
    /// <remarks>
    /// <li>
    /// <lu>определяем интерфейс абстракции;</lu>
    /// <lu>хранит ссылку на объект <see cref="Implementor"/></lu>
    /// </li>
    /// </remarks>
    class Abstraction
    {
        protected Implementor implementor;

        // Property
        public Implementor Implementor
        {
            get { return implementor; }
            set { implementor = value; }
        }

        public virtual void Operation()
        {
            implementor.Operation();
        }
    }

    /// <summary>
    /// Implementor - реализатор
    /// </summary>
    /// <remarks>
    /// <li>
    /// <lu>определяет интерфейс для классов реализации. Он не обязан точно
    /// соотведствовать интерфейсу класса <see cref="Abstraction"/>. На самом деле оба
    /// интерфейса могут быть совершенно различны. Обычно интерфейс класса
    /// <see cref="Implementor"/> представляет только примитивные операции, а класс
    /// <see cref="Abstraction"/> определяет операции более высокого уровня, 
    /// базирующиеся на этих примитивах;</lu>
    /// </li>
    /// </remarks>
    abstract class Implementor
    {
        public abstract void Operation();
    }

    /// <summary>
    /// RefinedAbstraction - уточненная абстракция
    /// </summary>
    /// <remarks>
    /// <li>
    /// <lu>расширяет интерфейс, определенный абстракцией <see cref="Abstraction"/></lu>
    /// </li>
    /// </remarks>
    class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            implementor.Operation();
        }
    }

    /// <summary>
    /// ConcreteImplementor - конкретный реализатор
    /// </summary>
    /// <remarks>
    /// <li>
    /// <lu>содержит конкретную реализацию интерфейса <see cref="Implementor"/></lu>
    /// </li>
    /// </remarks>
    class ConcreteImplementorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorA Operation");
        }
    }

    // "ConcreteImplementorB"

    class ConcreteImplementorB : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorB Operation");
        }
    }
}

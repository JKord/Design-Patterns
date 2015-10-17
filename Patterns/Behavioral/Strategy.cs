using System;

namespace Patterns.Behavioral.Strategy
{
    /// <summary>
    /// Інтерфейс «Стратегія» визначає функціональність (в даному прикладі це метод
    /// <see Cref="Algorithm"> Algorithm </see>), яка повинна бути реалізована
    /// конкретними класами стратегій. Іншими словами, метод інтерфейсу визначає
    /// вирішення якоїсь задачі, а його реалізації в конкретних класах стратегій визначають,
    /// яким шляхом ця задача буде вирішена.
    /// </ Summary>
    public interface IStrategy
    {
        void Algorithm();
    }

    /// <summary>
    /// Перша конкретна реалізація-стратегія.
    /// </summary>
    public class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("Виконується алгоритм стратегії 1.");
        }
    }

    /// <summary>
    /// Друга конкретна реалізація-стратегія.
    /// Реалізацій може бути скільки завгодно багато.
    /// </Summary>
    public class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("Виконується алгоритм стратегії 2.");
        }
    }

    /// <summary>
    /// Контекст, використовує стратегію для вирішення свого завдання.
    /// </summary>
    public class Context
    {
        /// <summary>
        /// Посилання на інтерфейс <see cref="IStrategy">IStrategy</see>
        /// дозволяє автоматично перемикатися між конкретними реалізаціями
        /// (іншими словами, це вибір конкретної стратегії).
        /// </summary>
        private IStrategy _strategy;

        /// <summary>
        /// Конструктор контексту.
        /// Ініціалізує об'єкт стратегією.
        /// </summary>
        /// <param name="strategy">
        /// Стратегія.
        /// </param>
        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        /// <summary>
        /// Метод для установки стратегії.
        /// Служить для зміни стратегії під час виконання.
        /// В C# може бути реалізований так само як властивість запису.
        /// </summary>
        /// <param name="strategy">
        /// Нова стратегія.
        /// </param>
        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        /// <summary>
        /// Деяка функціональність контексту, яка вибирає
        /// стратегію і використовує її для вирішення свого завдання.
        /// </summary>
        public void ExecuteOperation()
        {
            _strategy.Algorithm();
        }
    }
}

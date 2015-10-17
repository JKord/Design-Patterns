using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Structural.Facade
{
    /// <summary>
    /// Класс подсистемы
    /// </summary>
    /// <remarks>
    /// <li>
    /// <lu>реализует функциональность подсистемы;</lu>
    /// <lu>выполняет работу, порученную объектом <see cref="Facade"/>;</lu>
    /// <lu>ничего не "знает" о существовании фасада, то есть не хранит ссылок на него;</lu>
    /// </li>
    /// </remarks>
    internal class SubsystemA
    {
        internal string A1()
        {
            return "Subsystem A, Method A1\n";
        }
        internal string A2()
        {
            return "Subsystem A, Method A2\n";
        }
    }
    internal class SubsystemB
    {
        internal string B1()
        {
            return "Subsystem B, Method B1\n";
        }
    }
    internal class SubsystemC
    {
        internal string C1()
        {
            return "Subsystem C, Method C1\n";
        }
    }


    /// <summary>
    /// Facade - фасад
    /// </summary>
    /// <remarks>
    /// <li>
    /// <lu>"знает", каким классами подсистемы адресовать запрос;</lu>
    /// <lu>делегирует запросы клиентов подходящим объектам внутри подсистемы;</lu>
    /// </li>
    /// </remarks>
    public static class Facade
    {
        static SubsystemA a = new SubsystemA();
        static SubsystemB b = new SubsystemB();
        static SubsystemC c = new SubsystemC();

        public static void Operation1()
        {
            Console.WriteLine("Operation 1\n" +
            a.A1() +
            a.A2() +
            b.B1());
        }
        public static void Operation2()
        {
            Console.WriteLine("Operation 2\n" +
            b.B1() +
            c.C1());
        }
    }
}

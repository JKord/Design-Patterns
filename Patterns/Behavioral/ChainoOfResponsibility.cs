using System;

namespace Patterns.Behavioral.ChainoOfResponsibility
{
    public abstract class Chain
    {
        private Chain _next;

        public Chain Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public void Message(object command)
        {
            if (Process(command) == false && _next != null)
            {
                _next.Message(command);
            }
        }

        public static Chain operator +(Chain lhs, Chain rhs)
        {
            Chain last = lhs;
            while (last.Next != null)
            {
                last = last.Next;
            }
            last.Next = rhs;
            return lhs;
        }

        protected abstract bool Process(object command);
    }

    public class StringHandler : Chain
    {
        protected override bool Process(object command)
        {
            if (command is string)
            {
                Console.WriteLine("StringHandler can handle this message : {0}", (string)command);
                return true;
            }
            return false;
        }
    }

    public class IntegerHandler : Chain
    {
        protected override bool Process(object command)
        {
            if (command is int)
            {
                Console.WriteLine("IntegerHandler can handle this message : {0}", (int)command);
                return true;
            }
            return false;
        }
    }

    public class NullHandler : Chain
    {
        protected override bool Process(object command)
        {
            if (command == null)
            {
                Console.WriteLine("NullHandler can handle this message.");
                return true;
            }
            return false;
        }
    }

    public class IntegerBypassHandler : Chain
    {
        protected override bool Process(object command)
        {
            if (command is int)
            {
                Console.WriteLine("IntegerBypassHandler can handle this message : {0}", (int)command);
                return false; // Always pass to next handler
            }
            return false; // завжди передавати наступному обробникові
        }
    } 
}

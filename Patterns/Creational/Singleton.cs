using System;

namespace Patterns.Creational.Singleton
{
    public sealed class Singleton
    {
        static readonly Singleton myInstance =
           new Singleton();

        static Singleton() 
        {
            Console.WriteLine("Виклик одинака");
        }

        Singleton() { }

        public static Singleton MyInstance
        {
            get
            {
                return myInstance;
            }
        }
    }  
}

using System;

namespace Patterns.Creational.LazyInitialization
{
    public class LazyInitialization<T> where T : new()
    {
        protected LazyInitialization() { }

        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(T))
                    {
                        if (_instance == null)
                            _instance = new T();
                    }
                }
                return _instance;
            }
        }
    }

    public sealed class BigObject : LazyInitialization<BigObject>
    {
        public BigObject()
        {
            //Большая работа
            System.Threading.Thread.Sleep(3000);
            System.Console.WriteLine("Экземпляр BigObject создан");
        }
    }
}

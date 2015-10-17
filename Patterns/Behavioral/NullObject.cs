using System;

namespace Patterns.Behavioral.NullObject
{
    interface Animal
    {
        void MakeSound();
    }

    class Dog : Animal
    {
        public void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }

    class NullAnimal : Animal
    {
        public void MakeSound()
        {

        }
    }
}

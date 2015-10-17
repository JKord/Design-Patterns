using System;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            RunPatterns.Structural();
            Console.Read();

            RunPatterns.Creational();
            Console.Read();

            RunPatterns.Behavioral();
            Console.Read();
        }
    }
}

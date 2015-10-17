namespace Patterns.Creational.Prototype
{
    // "Prototype" 
    abstract class Prototype
    {
        private string id;

        // Constructor
        public Prototype(string id)
        {
            this.id = id;
        }

        // Property
        public string Id
        {
            get { return id; }
        }

        public abstract Prototype Clone();
    }

    // "ConcretePrototype1"

    class ConcretePrototype1 : Prototype
    {
        // Constructor
        public ConcretePrototype1(string id)
            : base(id)
        {
        }

        public override Prototype Clone()
        {
            // Shallow copy
            return (Prototype)this.MemberwiseClone();
        }
    }

    // "ConcretePrototype2"

    class ConcretePrototype2 : Prototype
    {
        // Constructor
        public ConcretePrototype2(string id)
            : base(id)
        {
        }

        public override Prototype Clone()
        {
            // Shallow copy
            return (Prototype)this.MemberwiseClone();
        }
    }
}

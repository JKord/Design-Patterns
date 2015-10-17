using System;
using System.Collections.Generic;

namespace Patterns.Behavioral.TemplateMethod
{
    public abstract class TemplateMethod
    {
        private Action CommonMethodSetToExecute;

        public abstract void DisplayOne();
        public abstract void DisplayTwo();
        public abstract void DisplayThree();

        private void DefaultMethodSetToExecute()
        {
            DisplayOne();
            DisplayTwo();
        }

        public void Execute(Action CommonMethodSetToExecute = null)
        {
            if (CommonMethodSetToExecute == null)
            {
                CommonMethodSetToExecute = DefaultMethodSetToExecute;
            }
            CommonMethodSetToExecute();
        }
    }
    public class TemplateMethodImp : TemplateMethod
    {
        public override void DisplayOne()
        {
            Console.WriteLine("Display method from the implmentor");
        }

        public override void DisplayTwo()
        {
            Console.WriteLine("Display two method from the implmentor");
        }

        public override void DisplayThree()
        {
            Console.WriteLine("Display three method from the implmentor");
        }
    }
}
